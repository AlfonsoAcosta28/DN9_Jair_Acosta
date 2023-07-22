using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Drawing;
using GymManager.DataAcces;
using GymManager.Core.MembershipTypes;
using GymManager.Core.Entities;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace GymManager.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly GymManagerContext context;
        const string mysqlConnectionString = "server=localhost;port=3306;database=gymmanager;user=root;password=1234;CharSet=utf8;SslMode=none;Pooling=false;AllowPublicKeyRetrieval=True;";


        public ApiController(GymManagerContext membersAppService)
        {
            this.context = membersAppService;
        }

       /* [HttpGet(nameof(GetMemberAsync) + "/{id}")]
        public ActionResult<Member> GetMemberAsync(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var result =  _membersAppService.GetMemberAsync(id);

            return Ok(result);
        }
       */
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            
            var result = context.Members.Find(id);


            return result;
        }

        [HttpGet(nameof(GetMembershipTypes))]
        public List<MembershipType> GetMembershipTypes()
        {
            var result = context.MembershipTypes.ToList();
            return result;
        }

        [HttpGet(nameof(GetAttendances))]
        public List<Attendance> GetAttendances()
        {
            return GetAttendancesPrivate();
        }

        private static List<Attendance> GetAttendancesPrivate()
        {
            List<Attendance> users = new List<Attendance>();
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();

            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetAllAttendace", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Attendance user = new Attendance
                    {
                        Id = (int)reader["Id"],
                        CheckIn = (DateTime)reader["CheckIn"],
                        CheckOut = (DateTime)reader["CheckOut"],
                        Member = new Member
                        {
                            Id = (int)reader["MemberId"],
                            Name = reader["Name"] as string,
                            LastName = reader["LastName"] as string
                        }
                    };
                    users.Add(user);
                }
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

        internal Member GetMemberById(int key)
        {
            MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(mysqlConnectionString);
            connection.Open();
            Member user = null;
            try
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("GetMembersById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("_id", key);

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new Member
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        LastName = reader["LastName"] as string,
                        BirthDay = (DateTime) reader["BirthDay"],
                        City = new City
                        {
                            Id =(int) reader["CityId"]
                        },
                        Email = reader["Email"] as string,
                        AllowNewsletter = (bool) reader["AllowNewsletter"]

                    };
                }
            }
            finally
            {

                connection.Close();
            }
            return user;
        }
    }
}
