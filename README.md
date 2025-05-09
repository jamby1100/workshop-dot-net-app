# Setting it up

```sh
# install microsoft sql server
curl -sSL https://packages.microsoft.com/keys/microsoft.asc | sudo tee /etc/apt/trusted.gpg.d/microsoft.asc
curl -sSL https://packages.microsoft.com/config/ubuntu/22.04/mssql-server-2022.list | sudo tee /etc/apt/sources.list.d/mssql-server.list
sudo apt update
sudo apt install -y mssql-server
sudo /opt/mssql/bin/mssql-conf setup
sudo systemctl start mssql-server
sudo systemctl enable mssql-server
# change the config in appsettings.json

# install the dotnet version
# look at global.json for the version
wget https://dot.net/v1/dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --version 8.0.404 --install-dir $HOME/dotnet
echo 'export DOTNET_ROOT=$HOME/dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$HOME/dotnet' >> ~/.bashrc
source ~/.bashrc
dotnet --version

# clone the repo
git clone https://github.com/jamby1100/workshop-dot-net-app
cd workshop-dot-net-app
dotnet tool install --global dotnet-ef
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.bashrc
source ~/.bashrc
dotnet ef --version

# run the migrations
dotnet ef database update --context WorkshopAppDbContext
dotnet ef database update --context AppIdentityDbContext

# install all the packages
dotnet restore

# run the server
dotnet run

# visit: http://localhost:5084/login?ReturnUrl=%2Fworkshops

# get a user from Models/DbModels/IdentitySeedData
```

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

dotnet ef migrations add WorkshopChallengesProgress --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext


dotnet ef migrations add AddChallengesProgress --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add AddLedgerModels --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add AddHintProgressStatus --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add RemoveUserIdFromHint --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add AddHintIdToHintProgress --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add RemoveNotNullConstraintOnWorkshopDescription --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add RemoveChallengeAndWorkshopAssociationsFromHintProgressTable --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add AddPriceToHints --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add ChangeLedgerPointsToDouble --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add AddPointsToChallenge --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext

dotnet ef migrations add AddWorkshopBrief --context WorkshopAppDbContext
dotnet ef database update --context WorkshopAppDbContext


dotnet ef database drop --context WorkshopAppDbContext --force 
dotnet ef database drop --context AppIdentityDbContext --force 

dotnet ef database update --context WorkshopAppDbContext
dotnet ef database update --context AppIdentityDbContext


```

```sh
dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.175
export PATH="$PATH:/Users/raphael.jambalos/.dotnet/tools"
libman init -p cdnjs

libman install font-awesome@6.2.1 -d wwwroot/lib/font-awesome
libman install bootstrap@5.2.3 -d wwwroot/lib/font-awesome

sudo apt-get update && sudo apt-get install -y dotnet-sdk-8.0

```
