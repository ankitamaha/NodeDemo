using System.Linq;

namespace DockerTestProject.Models {
    public static class DTPContextExtensions {
        public static void EnsureSeedData(this DTPContext context) {
            if (context.AllMigrationsApplied()) {
                if (!context.Profiles.Any()) {
                    // no Profiles have been saved, we can seed
                    context.Profiles.AddRange(
                        new Profile {
                            Id = 1,
                            AvatarURL = "https://avatars3.githubusercontent.com/u/176476?v=3&s=460",
                            FirstName = "Jared",
                            LastName = "Barboza",
                            Company = "Hudl"
                        },
                        new Profile {
                            Id = 2,
                            AvatarURL = "https://avatars3.githubusercontent.com/u/325529?v=3&s=460",
                            FirstName = "John",
                            LastName = "Bubriski",
                            Company = "StackOverflow"
                        }
                    );
                }
            }
        }
    }
}
