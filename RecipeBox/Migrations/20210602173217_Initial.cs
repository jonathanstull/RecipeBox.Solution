﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBox.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "AspNetRoles",
          columns: table => new
          {
            Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            Name = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
            NormalizedName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
            ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetRoles", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "AspNetUsers",
          columns: table => new
          {
            Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            UserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
            NormalizedUserName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
            Email = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
            NormalizedEmail = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
            EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            SecurityStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            PhoneNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
            LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
            LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
            AccessFailedCount = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUsers", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "AspNetRoleClaims",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            RoleId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            table.ForeignKey(
                      name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                      column: x => x.RoleId,
                      principalTable: "AspNetRoles",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "AspNetUserClaims",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            ClaimType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            ClaimValue = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            table.ForeignKey(
                      name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "AspNetUserLogins",
          columns: table => new
          {
            LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            ProviderKey = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            ProviderDisplayName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            table.ForeignKey(
                      name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "AspNetUserRoles",
          columns: table => new
          {
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            RoleId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            table.ForeignKey(
                      name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                      column: x => x.RoleId,
                      principalTable: "AspNetRoles",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "AspNetUserTokens",
          columns: table => new
          {
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            LoginProvider = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            Name = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
            Value = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            table.ForeignKey(
                      name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Ingredients",
          columns: table => new
          {
            IngredientId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
            table.ForeignKey(
                      name: "FK_Ingredients_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Ratings",
          columns: table => new
          {
            RatingId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            LucyStar = table.Column<int>(type: "int", nullable: false),
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Ratings", x => x.RatingId);
            table.ForeignKey(
                      name: "FK_Ratings_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Recipes",
          columns: table => new
          {
            RecipeId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Style = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Course = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            PrepDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            PrepTime = table.Column<int>(type: "int", nullable: false),
            UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Recipes", x => x.RecipeId);
            table.ForeignKey(
                      name: "FK_Recipes_AspNetUsers_UserId",
                      column: x => x.UserId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "IngredientRecipes",
          columns: table => new
          {
            IngredientRecipeId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            RecipeId = table.Column<int>(type: "int", nullable: false),
            IngredientId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_IngredientRecipes", x => x.IngredientRecipeId);
            table.ForeignKey(
                      name: "FK_IngredientRecipes_Ingredients_IngredientId",
                      column: x => x.IngredientId,
                      principalTable: "Ingredients",
                      principalColumn: "IngredientId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_IngredientRecipes_Recipes_RecipeId",
                      column: x => x.RecipeId,
                      principalTable: "Recipes",
                      principalColumn: "RecipeId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "RatingRecipes",
          columns: table => new
          {
            RatingRecipeId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            RatingId = table.Column<int>(type: "int", nullable: false),
            RecipeId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RatingRecipes", x => x.RatingRecipeId);
            table.ForeignKey(
                      name: "FK_RatingRecipes_Ratings_RatingId",
                      column: x => x.RatingId,
                      principalTable: "Ratings",
                      principalColumn: "RatingId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_RatingRecipes_Recipes_RecipeId",
                      column: x => x.RecipeId,
                      principalTable: "Recipes",
                      principalColumn: "RecipeId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_AspNetRoleClaims_RoleId",
          table: "AspNetRoleClaims",
          column: "RoleId");

      migrationBuilder.CreateIndex(
          name: "RoleNameIndex",
          table: "AspNetRoles",
          column: "NormalizedName",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_AspNetUserClaims_UserId",
          table: "AspNetUserClaims",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_AspNetUserLogins_UserId",
          table: "AspNetUserLogins",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_AspNetUserRoles_RoleId",
          table: "AspNetUserRoles",
          column: "RoleId");

      migrationBuilder.CreateIndex(
          name: "EmailIndex",
          table: "AspNetUsers",
          column: "NormalizedEmail");

      migrationBuilder.CreateIndex(
          name: "UserNameIndex",
          table: "AspNetUsers",
          column: "NormalizedUserName",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_IngredientRecipes_IngredientId",
          table: "IngredientRecipes",
          column: "IngredientId");

      migrationBuilder.CreateIndex(
          name: "IX_IngredientRecipes_RecipeId",
          table: "IngredientRecipes",
          column: "RecipeId");

      migrationBuilder.CreateIndex(
          name: "IX_Ingredients_UserId",
          table: "Ingredients",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_RatingRecipes_RatingId",
          table: "RatingRecipes",
          column: "RatingId");

      migrationBuilder.CreateIndex(
          name: "IX_RatingRecipes_RecipeId",
          table: "RatingRecipes",
          column: "RecipeId");

      migrationBuilder.CreateIndex(
          name: "IX_Ratings_UserId",
          table: "Ratings",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_Recipes_UserId",
          table: "Recipes",
          column: "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "AspNetRoleClaims");

      migrationBuilder.DropTable(
          name: "AspNetUserClaims");

      migrationBuilder.DropTable(
          name: "AspNetUserLogins");

      migrationBuilder.DropTable(
          name: "AspNetUserRoles");

      migrationBuilder.DropTable(
          name: "AspNetUserTokens");

      migrationBuilder.DropTable(
          name: "IngredientRecipes");

      migrationBuilder.DropTable(
          name: "RatingRecipes");

      migrationBuilder.DropTable(
          name: "AspNetRoles");

      migrationBuilder.DropTable(
          name: "Ingredients");

      migrationBuilder.DropTable(
          name: "Ratings");

      migrationBuilder.DropTable(
          name: "Recipes");

      migrationBuilder.DropTable(
          name: "AspNetUsers");
    }
  }
}
