﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OpenSettings.Migrations.PostgreSql.Data.Migrations.OpenSettings.OpenSettingsDb
{
    /// <inheritdoc />
    public partial class OpenSettingsDbMigration_v1_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReferenceId = table.Column<string>(type: "text", nullable: true),
                    ReferenceIdLowercase = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string[]>(type: "text[]", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsExpired = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Holder = table.Column<string>(type: "text", nullable: true),
                    HolderLowercase = table.Column<string>(type: "text", nullable: true),
                    Edition = table.Column<int>(type: "integer", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotBefore = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locks",
                columns: table => new
                {
                    Key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Owner = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locks", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    TypeLowercase = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ValueLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthScheme = table.Column<string>(type: "text", nullable: true),
                    OAuthProvider = table.Column<string>(type: "text", nullable: true),
                    ProviderId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmailLowercase = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    UsernameLowercase = table.Column<string>(type: "text", nullable: true),
                    HashedPassword = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Initials = table.Column<string>(type: "text", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGroups_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppGroups_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Identifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifiers_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Identifiers_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    Metadata = table.Column<string>(type: "text", nullable: true),
                    ExpiresIn = table.Column<TimeSpan>(type: "interval", nullable: true),
                    IsExpired = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiredOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatorName = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaimMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaimMappings", x => new { x.UserId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_UserClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "UserClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserClaimMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupClaimMappings",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ClaimId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupClaimMappings", x => new { x.GroupId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_UserGroupClaimMappings_UserClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "UserClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupClaimMappings_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupClaimMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroupMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupMappings", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleClaimMappings",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleClaimMappings", x => new { x.RoleId, x.ClaimId });
                    table.ForeignKey(
                        name: "FK_UserRoleClaimMappings_UserClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "UserClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleClaimMappings_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleClaimMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoleGroupMappings",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleGroupMappings", x => new { x.RoleId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserRoleGroupMappings_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleGroupMappings_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleGroupMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMappings", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoleMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNameLowercase = table.Column<string>(type: "text", nullable: true),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientNameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientIdLowercase = table.Column<string>(type: "text", nullable: true),
                    HashedClientSecret = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    WikiUrl = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_AppGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AppGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Apps_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroupNotificationMappings",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupNotificationMappings", x => new { x.GroupId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupNotificationMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserNotificationMappings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    IsOpened = table.Column<bool>(type: "boolean", nullable: false),
                    OpenedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsViewed = table.Column<bool>(type: "boolean", nullable: false),
                    ViewedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDismissed = table.Column<bool>(type: "boolean", nullable: false),
                    DismissedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationMappings", x => new { x.UserId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotificationMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppIdentifierMappings",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "integer", nullable: false),
                    IdentifierId = table.Column<int>(type: "integer", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppIdentifierMappings", x => new { x.AppId, x.IdentifierId });
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppIdentifierMappings_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppTagMappings",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTagMappings", x => new { x.AppId, x.TagId });
                    table.ForeignKey(
                        name: "FK_AppTagMappings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTagMappings_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTagMappings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StoreInSeparateFile = table.Column<bool>(type: "boolean", nullable: false),
                    IgnoreIndividualStoreInSeparateFile = table.Column<bool>(type: "boolean", nullable: false),
                    IgnoreOnFileChange = table.Column<bool>(type: "boolean", nullable: false),
                    IgnoreIndividualIgnoreOnFileChange = table.Column<bool>(type: "boolean", nullable: false),
                    RegistrationMode = table.Column<int>(type: "integer", nullable: false),
                    IgnoreIndividualRegistrationMode = table.Column<bool>(type: "boolean", nullable: false),
                    Consumer = table.Column<string>(type: "text", nullable: true),
                    Provider = table.Column<string>(type: "text", nullable: true),
                    IdentifierId = table.Column<int>(type: "integer", nullable: false),
                    AppId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NameLowercase = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    DynamicId = table.Column<string>(type: "text", nullable: true),
                    Urls = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    MachineName = table.Column<string>(type: "text", nullable: true),
                    Environment = table.Column<string>(type: "text", nullable: true),
                    ReloadStrategies = table.Column<int[]>(type: "integer[]", nullable: true),
                    ServiceType = table.Column<int>(type: "integer", nullable: false),
                    DataAccessType = table.Column<int>(type: "integer", nullable: true),
                    AppId = table.Column<int>(type: "integer", nullable: false),
                    IdentifierId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instances_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instances_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true),
                    ComputedIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SerializerType = table.Column<int>(type: "integer", nullable: false),
                    CompressionType = table.Column<int>(type: "integer", nullable: false),
                    CompressionLevel = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: true),
                    DataRestored = table.Column<bool>(type: "boolean", nullable: false),
                    DataValidationDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    StoreInSeparateFile = table.Column<bool>(type: "boolean", nullable: false),
                    IgnoreOnFileChange = table.Column<bool>(type: "boolean", nullable: true),
                    RegistrationMode = table.Column<int>(type: "integer", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    IsCopied = table.Column<bool>(type: "boolean", nullable: false),
                    CopiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdentifierId = table.Column<int>(type: "integer", nullable: false),
                    AppId = table.Column<int>(type: "integer", nullable: false),
                    CopiedFromId = table.Column<int>(type: "integer", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settings_Identifiers_IdentifierId",
                        column: x => x.IdentifierId,
                        principalTable: "Identifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settings_Settings_CopiedFromId",
                        column: x => x.CopiedFromId,
                        principalTable: "Settings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Settings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Settings_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Namespace = table.Column<string>(type: "text", nullable: true),
                    SettingId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingClasses_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingClasses_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SettingClasses_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true),
                    SerializerType = table.Column<int>(type: "integer", nullable: false),
                    CompressionType = table.Column<int>(type: "integer", nullable: false),
                    CompressionLevel = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    SettingId = table.Column<int>(type: "integer", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    RestoredById = table.Column<Guid>(type: "uuid", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingHistories_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingHistories_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SettingHistories_Users_RestoredById",
                        column: x => x.RestoredById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_CreatedById",
                table: "AppGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_NameLowercase",
                table: "AppGroups",
                column: "NameLowercase",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_Slug",
                table: "AppGroups",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_SortOrder",
                table: "AppGroups",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_AppGroups_UpdatedById",
                table: "AppGroups",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_CreatedById",
                table: "AppIdentifierMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_IdentifierId",
                table: "AppIdentifierMappings",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_SortOrder",
                table: "AppIdentifierMappings",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdentifierMappings_UpdatedById",
                table: "AppIdentifierMappings",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ClientId",
                table: "Apps",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ClientNameLowercase",
                table: "Apps",
                column: "ClientNameLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_CreatedById",
                table: "Apps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_GroupId",
                table: "Apps",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_Slug",
                table: "Apps",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_UpdatedById",
                table: "Apps",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppTagMappings_CreatedById",
                table: "AppTagMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppTagMappings_TagId",
                table: "AppTagMappings",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_AppId_IdentifierId",
                table: "Configurations",
                columns: new[] { "AppId", "IdentifierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CreatedById",
                table: "Configurations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_IdentifierId",
                table: "Configurations",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_UpdatedById",
                table: "Configurations",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_CreatedById",
                table: "Identifiers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_NameLowercase",
                table: "Identifiers",
                column: "NameLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_Slug",
                table: "Identifiers",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_SortOrder",
                table: "Identifiers",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Identifiers_UpdatedById",
                table: "Identifiers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_AppId_IdentifierId_Slug",
                table: "Instances",
                columns: new[] { "AppId", "IdentifierId", "Slug" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instances_IdentifierId",
                table: "Instances",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_NameLowercase",
                table: "Instances",
                column: "NameLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_Edition",
                table: "Licenses",
                column: "Edition");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_HolderLowercase",
                table: "Licenses",
                column: "HolderLowercase");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_IsExpired",
                table: "Licenses",
                column: "IsExpired");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ReferenceIdLowercase",
                table: "Licenses",
                column: "ReferenceIdLowercase",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedById",
                table: "Notifications",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UpdatedById",
                table: "Notifications",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SettingClasses_CreatedById",
                table: "SettingClasses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SettingClasses_SettingId",
                table: "SettingClasses",
                column: "SettingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettingClasses_UpdatedById",
                table: "SettingClasses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SettingHistories_CreatedById",
                table: "SettingHistories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SettingHistories_RestoredById",
                table: "SettingHistories",
                column: "RestoredById");

            migrationBuilder.CreateIndex(
                name: "IX_SettingHistories_SettingId",
                table: "SettingHistories",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingHistories_Slug_SettingId",
                table: "SettingHistories",
                columns: new[] { "Slug", "SettingId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettingHistories_Version",
                table: "SettingHistories",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_AppId_IdentifierId_ComputedIdentifier",
                table: "Settings",
                columns: new[] { "AppId", "IdentifierId", "ComputedIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CopiedFromId",
                table: "Settings",
                column: "CopiedFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CreatedById",
                table: "Settings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IdentifierId",
                table: "Settings",
                column: "IdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UpdatedById",
                table: "Settings",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedById",
                table: "Tags",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_NameLowercase",
                table: "Tags",
                column: "NameLowercase",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Slug",
                table: "Tags",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_SortOrder",
                table: "Tags",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UpdatedById",
                table: "Tags",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimMappings_ClaimId",
                table: "UserClaimMappings",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimMappings_CreatedById",
                table: "UserClaimMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_Slug",
                table: "UserClaims",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupClaimMappings_ClaimId",
                table: "UserGroupClaimMappings",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupClaimMappings_CreatedById",
                table: "UserGroupClaimMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMappings_CreatedById",
                table: "UserGroupMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMappings_GroupId",
                table: "UserGroupMappings",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupNotificationMappings_CreatedById",
                table: "UserGroupNotificationMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupNotificationMappings_NotificationId",
                table: "UserGroupNotificationMappings",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_Slug",
                table: "UserGroups",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationMappings_CreatedById",
                table: "UserNotificationMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationMappings_NotificationId",
                table: "UserNotificationMappings",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleClaimMappings_ClaimId",
                table: "UserRoleClaimMappings",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleClaimMappings_CreatedById",
                table: "UserRoleClaimMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleGroupMappings_CreatedById",
                table: "UserRoleGroupMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleGroupMappings_GroupId",
                table: "UserRoleGroupMappings",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_CreatedById",
                table: "UserRoleMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMappings_RoleId",
                table: "UserRoleMappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Slug",
                table: "UserRoles",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Slug",
                table: "Users",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppIdentifierMappings");

            migrationBuilder.DropTable(
                name: "AppTagMappings");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Locks");

            migrationBuilder.DropTable(
                name: "SettingClasses");

            migrationBuilder.DropTable(
                name: "SettingHistories");

            migrationBuilder.DropTable(
                name: "UserClaimMappings");

            migrationBuilder.DropTable(
                name: "UserGroupClaimMappings");

            migrationBuilder.DropTable(
                name: "UserGroupMappings");

            migrationBuilder.DropTable(
                name: "UserGroupNotificationMappings");

            migrationBuilder.DropTable(
                name: "UserNotificationMappings");

            migrationBuilder.DropTable(
                name: "UserRoleClaimMappings");

            migrationBuilder.DropTable(
                name: "UserRoleGroupMappings");

            migrationBuilder.DropTable(
                name: "UserRoleMappings");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Identifiers");

            migrationBuilder.DropTable(
                name: "AppGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
