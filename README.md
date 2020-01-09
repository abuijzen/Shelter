# Shelter 🐶🐱🐹🐰🦄

### Hoe bekom je de views

1. Ga in mapje Shelter.Mvc (cd Shelter.Mvc)
2. Dotnet run dit mapje
3. De tweede link openen in de browser

## Docker

- start our docker: `docker-machine start default`<br>
- to build the images: `docker-compose build`<br>
- to build the container: `docker-compose up`<br>
- now go to `localhost:8080` (mac) or `ip:8080` (windows)<br>

If you get an error about main-api try the following:

- stop docker: `docker-machine stop default`<br>
- start our docker: `docker-machine start default`<br>
- to build the container: `docker-compose up`<br>
- now go to `localhost:8080` (mac) or `ip:8080` (windows)<br>
