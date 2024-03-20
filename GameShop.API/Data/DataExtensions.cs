﻿using Microsoft.EntityFrameworkCore;

namespace GameShop.API.Data;

public static class DataExtensions
{
 public static void MigrateDb(this WebApplication app)
 {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GameShopContext>();
    dbContext.Database.Migrate();
 }
}