# DISP Eksamensprojekt stuff 

# Mangler i projekter
- ShareService mangler POST som ændre stock info korrekt 
- ShareService mangler korrekt appsetting.json med connection string til DB i cluster
- TobinTaxService mangler korrekt appsetting.json med connection string til DB i cluster
- ProviderService mangler korrekt appsetting.json med connection string til DB i cluster
- RequesterService mangler korrekt appsetting.json med connection string til DB i cluster
- TraderService mangler korrekt appsetting.json med connection string til DB i cluster
- Alle Db'er er ikke migrated endnu ***vent med at migrate, de virker fint***.

# Design valg
- Vi bruger Guid til alle vores Id'er for at få en unique identifier, som vi ikke skal tænke så meget over
- Alle services bør skrives i .NET
- EF-Core er benyttet grundet scaffolding, jeg håber på det ikke bliver en begrænsning senere henne. 
- Alle referencer til andre services, bør komme via enten env variabler eller fra appsettings.json for ikke at hardcode vædierne
- Der må kun persistereres data i de fem services med Db'er, andre projekter skal poste data på den ene eller anden måde til dem hvis der er behov for at persistere noget i dem
