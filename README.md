# Gamificación para la capacitación de guardias

Here lies the source code for the game (name not decided yet), its purpose is to educate guards in Ternium's more common and complicated situations in a fun and addictive way.
The game will consist in real life situations where the user will have to select the correct answer to the problem the game will present, fostering self-learning and retaining the information learned. The system will be accessed by using their employee ID with the purpose of monitoring employee activity and progress


## Table of contents

* [Client Details](#client-details)
* [Environment URLS](#environment-urls)
* [Da Team](#team)
* [Technology Stack](#technology-stack)
* [Management resources](#management-resources)
* [Setup the project](#setup-the-project)
* [Running the stack for development](#running-the-stack-for-development)
* [Stop the project](#stop-the-project)
* [Restoring the database](#restoring-the-database)
* [Debugging](#debugging)
* [Running specs](#running-specs)
* [Checking code for potential issues](#checking-code-for-potential-issues)


### Client Details

| Name               | Email             | Role |
| ------------------ | ----------------- | ---- |
| Ivineg  Vargas |c.ivargd@ternium.com.mx | Product Owner  |
| Salvador Guzman | c.sguzml@ternium.com.mx| Sistems adivsor  |
| Yetzaley Aracely Alvarado | c.yalvah@ternium.com.mx | Coordinator  |


### Environment URLS

* **Production** - [TBD](TBD)
* **Development** - [TBD](TBD)

### Da team

| Name           | Email             | Role        |
| -------------- | ----------------- | ----------- |
| Fabiana Serangelli Andrade | A01281445@itesm.mx | Development Team, Scrum Master |
| Oscar Lerma Franco | A01380817@itesm.mx | Development Team, Project Administrator |
| Raul Flores Gracia | A00820377@itesm.mx | Development Team, Configuration Administrator |
| Ricardo Reyes Alcala | 	A01281564@itesm.mx | Development Team, Product Owner Proxy |

### Technology Stack
| Technology    | Version      |
| ------------- | -------------|
| Unity | 2019.1     |
| Web GL  | 2.0     |

### Management tools

You should ask for access to this tools if you don't have it already:

* [Github repo](https://github.com/)
* [Backlog](https://trello.com/b/UXsHjwQ9/brigada-de-la-gamificaci%C3%B3n)
* [Documentation in Google Drive](https://drive.google.com/drive/folders/1hSnvCFzSxh5k6L1uqLL_Tl9V21jkyIzV)
* [Microsoft Teams](https://teams.microsoft.com/l/channel/19%3ab95b032363214d299ee713e734c3c07e%40thread.tacv2/General?groupId=c13a590f-8442-4453-bf96-cc9cc6fe360f&tenantId=c65a3ea6-0f7c-400b-8934-5a6dc1705645)
 
## Development

### Rules of using Git
We will have one branch per backlog item and branches will use this name scheme
{username}/{type of story}-{story number}/{story name}
branches will only be merged using pull request and asking for #TeraBlitz as reviewer and only he will resolve the pull request.

## Pull request format
# Description

Please include a summary of the change and/or which issue is fixed. Please also include relevant motivation and context. List any dependencies that are required for this change.

Fixes # (issue)

## Type of change

Please delete options that are not relevant.

- [ ] Bug fix (non-breaking change which fixes an issue)
- [ ] New feature (non-breaking change which adds functionality)
- [ ] Breaking change (fix or feature that would cause existing functionality to not work as expected)
- [ ] This change requires a documentation update

# How Has This Been Tested?

Please describe the tests that you ran to verify your changes. Provide instructions so we can reproduce. Please also list any relevant details for your test configuration

- [ ] Test A
- [ ] Test B

**Test Configuration**:
* Firmware version:
* Hardware:
* Toolchain:
* SDK:

# Checklist:

- [ ] My code follows the style guidelines of this project
- [ ] I have performed a self-review of my own code
- [ ] I have commented my code, particularly in hard-to-understand areas
- [ ] I have made corresponding changes to the documentation
- [ ] My changes generate no new warnings



### ALL OF THIS HAS NOT BEEN CHANGED
### Setup the project

You'll definitely want to install [`plis`](https://github.com/IcaliaLabs/plis), as in this case will
let you bring up the containers needed for development. This is done by running the command
`plis start`, which will start up the services in the `development` group (i.e. rails
and sidekiq), along with their dependencies (posgres, redis, etc).

After installing please you can follow this simple steps:

1. Clone this repository into your local machine

```bash
$ git clone git@github.com:IcaliaLabs/crowdfront.git
```

2. Fire up a terminal and run:

```bash
$ plis run web bash
```

3. Inside the container you need to migrate the database:

```
% rails db:migrate
```

### Running the stack for Development

1. Fire up a terminal and run: 

```
plis start
```

That command will lift every service crowdfront needs, such as the `rails server`, `postgres`, and `redis`.


It may take a while before you see anything, you can follow the logs of the containers with:

```
$ docker-compose logs
```

Once you see an output like this:

```
web_1   | => Booting Puma
web_1   | => Rails 5.1.3 application starting in development on http://0.0.0.0:3000
web_1   | => Run `rails server -h` for more startup options
web_1   | => Ctrl-C to shutdown server
web_1   | Listening on 0.0.0.0:3000, CTRL+C to stop
```

This means the project is up and running.

### Stop the project

In order to stop crowdfront as a whole you can run:

```
% plis stop
```

This will stop every container, but if you need to stop one in particular, you can specify it like:

```
% plis stop web
```

`web` is the service name located on the `docker-compose.yml` file, there you can see the services name and stop each of them if you need to.

### Restoring the database

You probably won't be working with a blank database, so once you are able to run crowdfront you can restore the database, to do it, first stop all services:

```
% plis stop
```

Then just lift up the `db` service:

```
% plis start db
```

The next step is to login to the database container:

```
% docker exec -ti crowdfront_db_1 bash
```

This will open up a bash session in to the database container.

Up to this point we just need to download a database dump and copy under `crowdfront/backups/`, this directory is mounted on the container, so you will be able to restore it with:

```
root@a3f695b39869:/# bin/restoredb crowdfront_dev db/backups/<databaseDump>
```

If you want to see how this script works, you can find it under `bin/restoredb`

Once the script finishes its execution you can just exit the session from the container and lift the other services:

```
% plis start
```

### Debugging

We know you love to use `debugger`, and who doesn't, and with Docker is a bit tricky, but don't worry, we have you covered.

Just run this line at the terminal and you can start debugging like a pro:

```
% plis attach web
```

This will display the logs from the rails app, as well as give you access to stop the execution on the debugging point as you would expect.

**Take note that if you kill this process you will kill the web service, and you will probably need to lift it up again.**

### Running specs

To run specs, you can do:

```
$ plis run test rspec
```

Or for a specific file:

```
$ plis run test rspec spec/models/user_spec.rb
```

### Checking code for potential issues

To run specs, you can do:

```
$ plis run web reek
```

```
$ plis run web rubocop
```

```
$ plis run web scss_lint
```

Or any other linter you have.
