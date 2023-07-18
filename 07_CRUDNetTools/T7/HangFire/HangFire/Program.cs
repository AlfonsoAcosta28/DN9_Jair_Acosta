using Hangfire;
using Hangfire.MySql;
using Hangfire.Server;
using HangFire.Helper;
using HangFire.Jobs;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("Default");

GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(conectionString, new MySqlStorageOptions
{
    TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
    QueuePollInterval = TimeSpan.FromSeconds(15),
    JobExpirationCheckInterval = TimeSpan.FromHours(1),
    CountersAggregateInterval = TimeSpan.FromMinutes(5),
    PrepareSchemaIfNecessary = true,
    DashboardJobListLimit = 50000,
    TransactionTimeout = TimeSpan.FromMinutes(1),
    TablesPrefix = "Hangfire"
}));

builder.Services.AddHangfire(configuration => configuration
.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings());

builder.Services.AddHangfireServer(JobStorage.Current, additionalProcesses: new IBackgroundProcess[] { new TestProcess()});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseHangfireDashboard();

app.UseEndpoints(endPoints =>
{
    endPoints.MapHangfireDashboard();


});

//RecurringJob.AddOrUpdate("myrecurringjob", () => DBHelper.Process(0,"Recurring"), Cron.Minutely);

//RecurringJob.RemoveIfExists("myrecurringjob");

app.Run();
