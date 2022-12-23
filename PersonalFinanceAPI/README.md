# PersonalFinance

Personal Finance API

# add fresh database

dotnet ef database drop -s .\PersonalFinanceAPI\ -p Persistance

dotnet ef database drop -s .\PersonalFinanceAPI\ -p Persistance --context DataContext

dotnet watch --no-hot-reload
