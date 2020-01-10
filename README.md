# Shelter 🐶🐱🐹🐰🦄

### Hoe bekom je de views

1. Ga in mapje Shelter.mvc (cd Shelter.mvc)
2. Dotnet run dit mapje
3. De tweede link openen in de browser

### User tests

- `cd /Shelter.UnitTests`<br>
- `dotnet test`<br>

## Docker

Voor ons project maken we gebruik van Docker. Onze docker maakt 2 containers aan:
- een container voor onze Api
- een container met onze (MySql) database

Wanneer wij onze docker containers hebben draaien, gaat die a.d.h.v. onze Startup.cs (Shelter.mvc) een connectie maken met de database.

Om het project te gebruiken:
- starten van docker (enkel windows): `docker-machine start default`<br>
- images aanmaken: `docker-compose build`<br>
- container aanmaken: `docker-compose up`<br>
- surf nu naar `localhost:8080` (mac) of `ip:8080` (windows)<br>
