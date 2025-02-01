
# Jamby's Corner

```sh
dotnet new globaljson --sdk-version 8.0.404 --output WorkshopApp
dotnet new mvc --no-https --output WorkshopApp --framework net8.0
dotnet new sln -o WorkshopApp
dotnet sln WorkshopApp add WorkshopApp
```

```sh
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 7.0.0

dotnet ef migrations add Initial

dotnet ef migrations add WorkshopChallenges
dotnet ef migrations add WorkshopChallengesSeed
```

```sh
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 7.0.0

dotnet ef migrations add Initial --context AppIdentityDbContext
dotnet ef database update --context AppIdentityDbContext
```