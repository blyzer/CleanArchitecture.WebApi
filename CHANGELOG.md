# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]
## v1.1-release

- Refactored Service Extension at Startup.cs
- code cleanup
- added response for confirm-email endpoint
- secured POST/DELETE/PUT Endpoints with JWT . Only Authorized Users can access these endpoints. To Generate a token, Register a new account at /api/account/register. Get it confirmed. Generate JWTokens at /api/account/authenticate and use the tokens to access the secured endpoints.
- added default roles (SuperAdmin,Admin,Moderator,Basic). Found at Application/Enums/Roles
- added default roles seeding on startup
- added default users seeding at startup. Here are the default credentials ( superadmin@gmail.com / 123Pa$$word! ) ( basic@gmail.com / 123Pa$$word! )
- updated nugget packages
- added custom response for 401 & 403
- any newly registered user will be added to the Basic User Role. All associated roles of a user will be visible on /api/Account/authenticate response.
- added forgot-password / reset-password endpoints
- added basic health check at /health
- added user auditing to track changes / creation of new entities by userId

## Released
## v1.0-preview

### Added
- setup folder structure
- added Swagger UI
- added API Versioning
- added Meta Controller
- added base API Controller
- added Generic Repostiory with Interface / Implementation
- added response and paged response wrapper classes
- added identity context and seperate connection string for Identity
- custom schema and names for Identity Table
- added automapper with general profile
- added endpoints and handlers for product /getall and /post
- added pagination filters and implemented pagination for GetAll Method of Generic Repository
- added fluent validations
- and more.

### Changed
- None


<a name="1.2.0"></a>
## [1.2.0](https://www.github.com/blyzer/CleanArchitecture.WebApi/releases/tag/v1.2.0) (2021-5-21)

### Features

* code vs ([36e6e1b](https://www.github.com/blyzer/CleanArchitecture.WebApi/commit/36e6e1b1a388217e0f7ecf15512aaf5088a76025))
* Implement Type parameter ([ff2ece3](https://www.github.com/blyzer/CleanArchitecture.WebApi/commit/ff2ece39b32e79f28deeadf475cab30db351344e))
* migrate to .NET5 ([c4ac6f2](https://www.github.com/blyzer/CleanArchitecture.WebApi/commit/c4ac6f2bc1ef9405aef7c8ebea8db4acbe705cff))

