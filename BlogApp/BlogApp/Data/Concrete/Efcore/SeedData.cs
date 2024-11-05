using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.Efcore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        // Bir method tanımlayıp IApplicationBuilder app parametresi atıyoruz 
        // Peki neden app parametresi atıyoruz ? 
        // var app = Builder.Build(app);  : projemiz Builder üzerinden Build edilerek app parametresi atıyoruz 
        // ardından bunuda app değişkenine var dieyerek atıyroz 
        // Builder projemizin kütüphanesinde olan Services parametresini hali hazırda
        // addDbContext builder.Services.AddDbContext<BlogContext> dieyerek veri tabanı bağalntısını yapıyoruz
        // bu nedenden dolayı direk local veritabanını projemizize dahil edebliyoruz.
        // proje bitiği zamada default duruma getiriyouz.                                                              
        // app.Run(); Uygulmamızı çalışıtyoruz.                                   

        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            // context değişkenine yularıda verdiğimiz app parametresi üzerinden ApplicationServices dieyrek bir servis oluşturuyoz 
            // ve servis içerisinde CreateScope diyerek bir servis kapsamı oluşuturuyoruz ve bu serivis kapsamının içerisindede
            // ServicesProvider diyrek bir local veri tabanı alanı oluşturuyoruz bu oluşturan veri tabaı içerisindede GetServices diyerek'de 
            // BlogContext erişiiyourz.   

            if (context != null) // benim gelen contextim null gelmiyor ise.
            {
                if (context.Database.GetPendingMigrations().Any())
                // context üzerinden gelen Databaseimin GetPendingMigrations methodundan Any dieyrek herahngi bir veri var ise sen gel 
                // Database oluştur uygulama her çalıştığında sadece bir kere 
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                            new Tag { Text = "Web Programlama", Url = "Web Programlama", Color = TagColors.primary },
                            new Tag { Text = "Backend", Url = "Backend", Color = TagColors.danger },
                            new Tag { Text = "Frontend", Url = "Frontend", Color = TagColors.secondary },
                            new Tag { Text = "FullStack", Url = "FullStack", Color = TagColors.success },
                            new Tag { Text = "Php", Url = "Php", Color = TagColors.warning }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "fatihakdaaq", Image = "man.png", Name = "Fatih", Email = "Fatih@gmail.com", Password = "123456" },
                        new User { UserName = "Zeynep", Image = "woman.png", Name = "Zeynep", Email = "Zeynep@gmail.com", Password = "123456" }
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp Net Core",
                            Description = "Asp Net Core Dersleri",
                            Content = "Asp Net Core Dersleri",
                            Url = "Asp-Net-Core",
                            IsActive = true,
                            Image = "1.jpg",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 2,
                            Comments = new List<Comment>
                            {
                                new Comment{ Text = "Güzel Yaratıcı bir kurs" , PublishedOn = new DateTime(), UserId = 1},
                                new Comment{ Text = "Baya iyi" , PublishedOn =  new DateTime(), UserId = 2}
                            }
                        },
                        new Post
                        {
                            Title = "Dart Flutter",
                            Description = "Dart FLutter Dersleri",
                            Content = "Dart FLutter Dersleri",
                            Url = "Dart-Flutter",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Image = "2.jpg",
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 2,
                            Comments = new List<Comment>
                            {
                                new Comment{ Text = "Güzel Yaratıcı bir kurs" , PublishedOn = new DateTime(), UserId = 1},
                                new Comment{ Text = "Baya iyi" , PublishedOn =  new DateTime(), UserId = 2}
                            }
                        },
                        new Post
                        {
                            Title = "JavaScript",
                            Description = "JavaScript Dersleri",
                            Content = "JavaScript Dersleri",
                            Url = "JavaScript",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(1).ToList(),
                            UserId = 1,
                            Comments = new List<Comment>
                            {
                                new Comment{ Text = "Güzel Yaratıcı bir kurs" , PublishedOn = new DateTime(), UserId = 1},
                                new Comment{ Text = "Baya iyi" , PublishedOn =  new DateTime(), UserId = 2}
                            }
                        },
                        new Post
                        {
                            Title = "C#",
                            Description = "C# Dersleri",
                            Content = "C# Dersleri",
                            Url = "C",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-25),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 1,
                            Comments = new List<Comment>
                            {
                                new Comment{ Text = "Güzel Yaratıcı bir kurs" , PublishedOn = new DateTime(), UserId = 1},
                                new Comment{ Text = "Baya iyi" , PublishedOn =  new DateTime(), UserId = 2}
                            }
                        }
                        ,
                        new Post
                        {
                            Title = "React",
                            Description = "React Dersleri",
                            Content = "React Dersleri",
                            Url = "react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(5).ToList(),
                            UserId = 1,
                            Comments = new List<Comment>
                            {
                                new Comment{ Text = "Güzel Yaratıcı bir kurs" , PublishedOn = new DateTime(), UserId = 1},
                                new Comment{ Text = "Baya iyi" , PublishedOn =  new DateTime(), UserId = 2}
                            }
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}

// Dependency Injection (Bağımlılık Enjeksiyonu) 

// Scoped Hizmetlerin Özellikleri
// Her İstek için Tek Örnek: Scoped olarak tanımlanmış bir hizmet,
// bir HTTP isteği boyunca tek bir örnek olarak oluşturulur ve bu istek kapsamında aynı örnek kullanılır.

