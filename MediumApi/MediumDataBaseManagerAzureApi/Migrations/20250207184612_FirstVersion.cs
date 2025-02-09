using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediumDataBaseManagerAzureApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentStates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReadingList_UserWrapperToStoryIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingList_UserWrapperToStoryIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Users = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserWrapperId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentStateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_ContentStates_ContentStateId",
                        column: x => x.ContentStateId,
                        principalTable: "ContentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityMaps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentStateKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DictonaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mutability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityMaps", x => x.id);
                    table.ForeignKey(
                        name: "FK_EntityMaps_ContentStates_ContentStateKey",
                        column: x => x.ContentStateKey,
                        principalTable: "ContentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWrappers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWrappers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserWrappers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictonaryDataInBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    DictonaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    obj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictonaryDataInBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictonaryDataInBlocks_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    offset = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<int>(type: "int", nullable: false),
                    key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityRanges_Blocks_Id",
                        column: x => x.Id,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InlineStylesRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockId = table.Column<int>(type: "int", nullable: false),
                    offset = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<int>(type: "int", nullable: false),
                    style = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InlineStylesRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InlineStylesRanges_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentStateAboutUserWrappers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentStateModelAboutUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaveLastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentStateAboutUserWrappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentStateAboutUserWrappers_ContentStates_ContentStateModelAboutUserId",
                        column: x => x.ContentStateModelAboutUserId,
                        principalTable: "ContentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentStateAboutUserWrappers_UserWrappers_UserId",
                        column: x => x.UserId,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentStateStoryWrappers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoryCreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaveLastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserWrapperUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentStateStoryWrappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentStateStoryWrappers_ContentStates_Id",
                        column: x => x.Id,
                        principalTable: "ContentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentStateStoryWrappers_UserWrappers_StoryCreatorId",
                        column: x => x.StoryCreatorId,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentStateStoryWrappers_UserWrappers_UserWrapperUserId",
                        column: x => x.UserWrapperUserId,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdToFollow = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follows_UserWrappers_UserID",
                        column: x => x.UserID,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMemberShips",
                columns: table => new
                {
                    UserWrapperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMemberShips", x => x.UserWrapperId);
                    table.ForeignKey(
                        name: "FK_UserMemberShips_UserWrappers_UserWrapperId",
                        column: x => x.UserWrapperId,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserWrapperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserWrapperId);
                    table.ForeignKey(
                        name: "FK_UserProfiles_UserWrappers_UserWrapperId",
                        column: x => x.UserWrapperId,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryToAuthorsConectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserWrapperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentStateWrapperId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryToAuthorsConectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryToAuthorsConectors_ContentStateStoryWrappers_ContentStateWrapperId",
                        column: x => x.ContentStateWrapperId,
                        principalTable: "ContentStateStoryWrappers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoryToAuthorsConectors_UserWrappers_UserWrapperId",
                        column: x => x.UserWrapperId,
                        principalTable: "UserWrappers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TopicToStoryConectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    ContentStateWrapperId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicToStoryConectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicToStoryConectors_ContentStateStoryWrappers_ContentStateWrapperId",
                        column: x => x.ContentStateWrapperId,
                        principalTable: "ContentStateStoryWrappers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicToStoryConectors_Topics_TopicId1",
                        column: x => x.TopicId1,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_ContentStateId",
                table: "Blocks",
                column: "ContentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentStateAboutUserWrappers_ContentStateModelAboutUserId",
                table: "ContentStateAboutUserWrappers",
                column: "ContentStateModelAboutUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentStateAboutUserWrappers_UserId",
                table: "ContentStateAboutUserWrappers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentStateStoryWrappers_StoryCreatorId",
                table: "ContentStateStoryWrappers",
                column: "StoryCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentStateStoryWrappers_UserWrapperUserId",
                table: "ContentStateStoryWrappers",
                column: "UserWrapperUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DictonaryDataInBlocks_BlockId",
                table: "DictonaryDataInBlocks",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityMaps_ContentStateKey",
                table: "EntityMaps",
                column: "ContentStateKey");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserID",
                table: "Follows",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_InlineStylesRanges_BlockId",
                table: "InlineStylesRanges",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryToAuthorsConectors_ContentStateWrapperId",
                table: "StoryToAuthorsConectors",
                column: "ContentStateWrapperId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryToAuthorsConectors_UserWrapperId",
                table: "StoryToAuthorsConectors",
                column: "UserWrapperId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicToStoryConectors_ContentStateWrapperId",
                table: "TopicToStoryConectors",
                column: "ContentStateWrapperId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicToStoryConectors_TopicId1",
                table: "TopicToStoryConectors",
                column: "TopicId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentStateAboutUserWrappers");

            migrationBuilder.DropTable(
                name: "DictonaryDataInBlocks");

            migrationBuilder.DropTable(
                name: "EntityMaps");

            migrationBuilder.DropTable(
                name: "EntityRanges");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "InlineStylesRanges");

            migrationBuilder.DropTable(
                name: "ReadingList_UserWrapperToStoryIds");

            migrationBuilder.DropTable(
                name: "StoryToAuthorsConectors");

            migrationBuilder.DropTable(
                name: "TopicToStoryConectors");

            migrationBuilder.DropTable(
                name: "UserMemberShips");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "ContentStateStoryWrappers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "ContentStates");

            migrationBuilder.DropTable(
                name: "UserWrappers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
