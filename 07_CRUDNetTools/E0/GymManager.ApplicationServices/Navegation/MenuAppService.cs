using GymManager.Core.Navegation;

namespace GymManager.ApplicationServices.Navegation
{
    public class MenuAppService : IMenuAppService
    {
        public List<UserMenuItem> GetMenu()
        {
            List<UserMenuItem> menu = new List<UserMenuItem> ();

            menu.Add(new UserMenuItem
            {
                Name = "HOME",
                DisplayName = "HOME",
                Order = 0,
                Url = "/",
                Icon = "house-fill"
            });

            menu.Add(new UserMenuItem
            {
                Name = "ADMINISTRATION",
                DisplayName = "ADMINISTRATION",
                Order = 1,
                Url = "#",
                Icon = "file-earmark",
                Items = new List<UserMenuItem>()
                {
                    new UserMenuItem
                    {
                        Name = "MembershipTypes",
                        DisplayName = "Membership Types",
                        Order = 0,
                        Url = "/MembershipTypes/"
                    },

                    new UserMenuItem
                    {
                        Name = "InventoryUnits",
                        DisplayName = "Inventory Units",
                        Order = 1,
                        Url = "/InventoryUnits/"
                    },

                     new UserMenuItem
                    {
                        Name = "EquipmentTypes",
                        DisplayName = "Equipment Types",
                        Order = 2,
                        Url = "/EquipmentTypes/"
                    },

                       new UserMenuItem
                    {
                        Name = "EquipmentInventory",
                        DisplayName = "Equipment Inventory",
                        Order = 3,
                        Url = "/EquipmentInventory/"
                    },
                        new UserMenuItem
                    {
                        Name = "UserManagement",
                        DisplayName = "Users",
                        Order = 4,
                        Url = "/Users/"
                    }
                }
            }) ;


            menu.Add(new UserMenuItem
            {
                Name = "STORE",
                DisplayName = "STORE",
                Order = 2,
                Url = "#",
                Icon = "cart",
                Items = new List<UserMenuItem>
                {

                    new UserMenuItem
                    {
                        Name = "Shopping",
                        DisplayName = "Shopping",
                        Order = 0,
                        Url = "/Shopping/"
                    },

                    new UserMenuItem
                    {
                        Name = "ProductInventury",
                        DisplayName = "Product Inventury",
                        Order = 1,
                        Url = "/ProductInventury/"
                    },

                     new UserMenuItem
                    {
                        Name = "ProductTypes",
                        DisplayName = "Product Types",
                        Order = 2,
                        Url = "/ProductTypes/"
                    },

                      new UserMenuItem
                    {
                        Name = "ProductCategories",
                        DisplayName = "Product Categories",
                        Order = 3,
                        Url = "/ProductCategories/"
                    }
                }

            });


            menu.Add(new UserMenuItem
            {
                Name = "MEMBERS",
                DisplayName = "MEMBERS",
                Order = 3,
                Url = "#",
                Icon = "people",
                Items = new List<UserMenuItem>
                {

                    new UserMenuItem
                    {
                        Name = "MembersManagement",
                        DisplayName = "Menagement",
                        Order = 0,
                        Url = "/Members/"
                    },

                     new UserMenuItem
                    {
                        Name = "MembersManagement",
                        DisplayName = "Membership Reewal",
                        Order = 1,
                        Url = "/Members/Renewal/"
                    },

                    new UserMenuItem
                    {
                        Name = "CheckIn",
                        DisplayName = "CheckIn",
                        Order = 2,
                        Url = "/Attendance/MemberIn"
                    },

                    new UserMenuItem
                    {
                        Name = "CheckOut",
                        DisplayName = "CheckOut",
                        Order = 3,
                        Url = "/Attendance/MemberOut"
                    },
                }
            });


            menu.Add(new UserMenuItem
            {
                Name = "INVOICING",
                DisplayName = "INVOICING",
                Order = 4,
                Url = "/Invoicing/GenereteInvoice",
                Icon = "graph-up"
            });


            menu.Add(new UserMenuItem
            {
                Name = "REPORTS",
                DisplayName = "REPORTS",
                Order = 5,
                Url = "#",
                Icon = "puzzle",
                Items = new List<UserMenuItem>
                {

                    new UserMenuItem
                    {
                        Name = "NewMemberReport",
                        DisplayName = "New Member",
                        Order = 0,
                        Url = "/Reports/NewMembers"
                    },

                    new UserMenuItem
                    {
                        Name = "AttendanceReport",
                        DisplayName = "Attendace",
                        Order = 1,
                        Url = "/Reports/Attendance"
                    },

                     new UserMenuItem
                    {
                        Name = "MembershipRenewalReport",
                        DisplayName = "Membership Renewal",
                        Order = 2,
                        Url = "/Reports/MembershipRenewal"
                    },

                }
            });


            return menu;
        }
    }
}
