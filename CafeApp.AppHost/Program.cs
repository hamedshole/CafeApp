var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CafeApp_Web>("cafeapp-web");

builder.Build().Run();
