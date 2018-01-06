using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPress.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meta",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    key = table.Column<string>(type: "TINYTEXT", nullable: false),
                    model = table.Column<string>(type: "VARCHAR(45)", nullable: false, defaultValueSql: "'article'"),
                    model_id = table.Column<long>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TINYTEXT", nullable: true),
                    permissions = table.Column<string>(type: "LONGTEXT", nullable: true, defaultValueSql: "NULL"),
                    reference = table.Column<string>(type: "VARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "terms",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    image_id = table.Column<long>(nullable: true),
                    name = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    parent_id = table.Column<long>(nullable: true),
                    post_type = table.Column<string>(type: "VARCHAR(45)", nullable: true, defaultValueSql: "'article'"),
                    url = table.Column<string>(type: "TINYTEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terms", x => x.id);
                    table.ForeignKey(
                        name: "FK_terms_terms_parent_id",
                        column: x => x.parent_id,
                        principalTable: "terms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date_created = table.Column<string>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    date_last_login = table.Column<string>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    email = table.Column<string>(type: "VARCHAR(45)", nullable: false),
                    name = table.Column<string>(type: "TINYTEXT", nullable: true),
                    password = table.Column<string>(type: "VARCHAR(128)", nullable: false),
                    username = table.Column<string>(type: "VARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    author_id = table.Column<long>(nullable: false, defaultValueSql: "0")
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "LONGTEXT", nullable: true),
                    date_created = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    date_modified = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    date_publish = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    password = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    status = table.Column<string>(type: "VARCHAR(16)", nullable: true, defaultValueSql: "'draft'"),
                    summary = table.Column<string>(type: "TINYTEXT", nullable: true),
                    title = table.Column<string>(type: "TINYTEXT", nullable: false),
                    type = table.Column<string>(type: "VARCHAR(64)", nullable: true, defaultValueSql: "'article'"),
                    url = table.Column<string>(type: "TINYTEXT", nullable: false),
                    visibility = table.Column<string>(type: "VARCHAR(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    comment = table.Column<string>(nullable: true),
                    date = table.Column<string>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    email = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    name = table.Column<string>(type: "TINYTEXT", nullable: true),
                    post_id = table.Column<long>(nullable: false, defaultValueSql: "0")
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<string>(type: "VARCHAR(16)", nullable: false, defaultValueSql: "'awaiting'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "comments.fk_comments_1_idx",
                table: "comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "meta.index2",
                table: "meta",
                column: "model");

            migrationBuilder.CreateIndex(
                name: "posts.fk_posts_1_idx",
                table: "posts",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "posts.type",
                table: "posts",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_posts_url",
                table: "posts",
                column: "url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_reference",
                table: "roles",
                column: "reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "terms.fk_terms_1_idx",
                table: "terms",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_terms_url",
                table: "terms",
                column: "url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "meta");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "terms");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
