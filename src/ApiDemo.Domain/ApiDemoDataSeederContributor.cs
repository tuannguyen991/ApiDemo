using System;
using System.Threading.Tasks;
using ApiDemo.Authors;
using ApiDemo.Books;
using ApiDemo.Categories;
using ApiDemo.ReadingPackages;
using ApiDemo.Users;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace ApiDemo
{
    public class ApiDemoDataSeedContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IReadingPackageRepository _readingPackageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;

        public ApiDemoDataSeedContributor(
            IGuidGenerator guidGenerator,
            IReadingPackageRepository readingPackageRepository,
            IUserRepository userRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            IBookRepository bookRepository
        )
        {
            _guidGenerator = guidGenerator;
            _readingPackageRepository = readingPackageRepository;
            _userRepository = userRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var option = context.Properties["option"];
            switch (option)
            {
                case Option.InitialPrimary:
                    await SeedReadingPackageAsync();
                    // await SeedUserAsync();
                    await SeedAuthorAsync();
                    await SeedCategoryAsync();
                    await SeedBookAsync();
                    break;

                case Option.InitialSecondary:
                    // await SeedUserReadingPackagesAsync();
                    // await SeedUserHistoriesAsync();
                    // await SeedUserLibrariesAsync();
                    // await SeedHighlightsAsync();
                    await SeedBookWithAuthorsAsync();
                    await SeedBookWithCategoriesAsync();
                    break;

                default:
                    break;
            }
        }

        public async Task SeedUserAsync()
        {
            var userBac = new User(
                UserBac.ID,
                "Bắc",
                "Ngô Thị Hà",
                "bac.ngo.bker2019@hcmut.edu.vn",
                new DateTime(2001, 07, 27)
            );

            userBac.ImageLink = $"Content\\Images\\{UserBac.ID}\\avatarBac.jpg";


            await _userRepository.InsertManyAsync(
                new[] { userBac }
            );
        }

        public async Task SeedReadingPackageAsync()
        {
            var packageBasic = new ReadingPackage(
                _guidGenerator.Create(),
                ReadingPackageName.BASIC,
                (new TimeSpan(30, 0, 0, 0)).ToString("c"),
                50000,
                Currency.VND,
                0
            );

            var packageStandard = new ReadingPackage(
                _guidGenerator.Create(),
                ReadingPackageName.STANDARD,
                (new TimeSpan(30 * 3, 0, 0, 0)).ToString("c"),
                150000,
                Currency.VND,
                16
            );

            var packageEconomics = new ReadingPackage(
                _guidGenerator.Create(),
                ReadingPackageName.ECONOMICS,
                (new TimeSpan(365, 0, 0, 0)).ToString("c"),
                600000,
                Currency.VND,
                25
            );

            await _readingPackageRepository.InsertManyAsync(
                new[] { packageBasic, packageStandard, packageEconomics }
            );
        }
        public async Task SeedAuthorAsync()
        {
            var authorRowling = new Author(
                _guidGenerator.Create(),
                AuthorName.ROWLING,
                new DateTime(1965, 07, 31),
                "Joanne Rowling was born on 31st July 1965 at Yate General Hospital near Bristol",
                "https://www.dropbox.com/s/wholj2q1o8floky/rowling.jpg?raw=1"
            );

            var authorGray = new Author(
                _guidGenerator.Create(),
                AuthorName.GRAY,
                new DateTime(1970, 04, 13),
                "Eva Gray introduces the reader to a world that has been destroyed by war - a war that is still going on - and four girls that are sent to a boarding school by their parents.",
                "https://www.dropbox.com/s/mibsvj4w9vapg8f/gray.jpg?raw=1"
            );

            var authorReyes = new Author(
                _guidGenerator.Create(),
                AuthorName.REYES,
                new DateTime(1960, 01, 19),
                "Dr. Teofilo Reyes is a man of many talents and has done a lot of important work.",
                "https://www.dropbox.com/s/elsved97ghg1dcu/reyes.jpg?raw=1"
            );

            var authorJarayaman = new Author(
                _guidGenerator.Create(),
                AuthorName.JAYARAMAN,
                new DateTime(1975, 04, 03),
                "Saru Jayaraman is an advocate for fair wages for restaurant workers and other service workers in the United States.",
                "https://www.dropbox.com/s/b0juuv3gquzjukb/jayaraman.jpg?raw=1"
            );

            var authorHorowitz = new Author(
                _guidGenerator.Create(),
                AuthorName.HOROWITZ,
                new DateTime(1966, 06, 13),
                "Ben Horowitz is a technology entrepreneur and co-founder along with Marc Andreessen of the venture capital firm Andreessen Horowitz.",
                "https://www.dropbox.com/s/nwt165e08isa2cj/horowitz.jpg?raw=1"
            );

            var authorBanerjee = new Author(
                _guidGenerator.Create(),
                AuthorName.BANERJEE,
                new DateTime(1961, 02, 21),
                "Abhijit V. Banerjee is an Indian-American economist who is currently the Ford Foundation International Professor of Economics at Massachusetts Institute of Technology.",
                "https://www.dropbox.com/s/7r4lpu0yeomvzp6/banerjee.jpg?raw=1"
            );

            var authorDuflo = new Author(
                _guidGenerator.Create(),
                AuthorName.DUFLO,
                new DateTime(1972, 10, 25),
                "Esther Duflo is a French - American economist who is a professor of Poverty Alleviation and Development Economics at the Massachusetts Institute of Technology (MIT).",
                "https://www.dropbox.com/s/jfqoeds369pw83m/duflo.jpg?raw=1"
            );

            await _authorRepository.InsertManyAsync(
                new[] { authorRowling, authorGray, authorReyes, authorJarayaman, authorHorowitz, authorBanerjee, authorDuflo }
            );
        }

        public async Task SeedCategoryAsync()
        {
            var categoryStories = new Category(
               _guidGenerator.Create(),
               CategoryName.STORIES,
               "https://www.dropbox.com/s/f7lqsdj9fo9yvn5/stories.jpg?raw=1"
            );

            var categoryFiction = new Category(
               _guidGenerator.Create(),
               CategoryName.FICTION,
               "https://www.dropbox.com/s/fwce7e0lgtv8mwl/fiction.jpg?raw=1"
            );

            var categoryBusiness = new Category(
               _guidGenerator.Create(),
               CategoryName.BUSINESS,
               "https://www.dropbox.com/s/xgecqyp722ba1lc/business.jpg?raw=1"
            );

            var categoryEconomy = new Category(
               _guidGenerator.Create(),
               CategoryName.ECONOMY,
               "https://www.dropbox.com/s/kwnvxukbw0430dp/economy.jpg?raw=1"
            );

            await _categoryRepository.InsertManyAsync(
                new[] { categoryStories, categoryFiction, categoryBusiness, categoryEconomy }
            );
        }

        public async Task SeedBookAsync()
        {
            var bookStone = new Book(
               "3a0a34f5-8fa3-9e82-1b0e-1682c3c92a2d",
               BookTitle.STONE,
               "",
               332,
               "",
               "https://www.dropbox.com/s/j9pf3xawyz6cyzc/stone.jpg?raw=1",
               "Harry Potter thinks he is an ordinary boy - until he is rescued by a beetle eyed giant of a man, enrols at Hogwarts School of Witchcraft and Wizardry, learns to play Quidditch and does battle in a deadly duel. All because Harry Potter is a wizard! Follow the adventures of Harry Potter as he discovers the magical, the dangerous, the unpredictable world of Hogwarts School of Witchcraft and Wizardry."
            );

            var bookPrince = new Book(
               "3a0a34f5-8fa3-5349-622f-d4620ed3c2b8",
               BookTitle.PRINCE,
               "",
               1008,
               "",
               "https://www.dropbox.com/s/37skw74bz3gys9a/prince.jpg?raw=1",
               "'In a brief statement on Friday night, Minister for Magic Cornelius Fudge confirmed that He Who Must Not Be Named has returned to this country and is once more active. \"It is with great regret that I must confirm that the wizard styling himself Lord - well, you know who I mean - is alive and among us again,\" said Fudge.' These dramatic words appeared in the final pages ofHarry Potter and the Order of the Phoenix. In the midst of this battle of good and evil,Harry Potter and the Half-Blood Prince takes up the story of Harry Potter's sixth year at Hogwarts School of Witchcraft and Wizardry, with Voldemort's power and followers increasing day by day ..."
            );

            var bookGates = new Book(
               "b848b9fb-65c0-4691-8b34-39bca5e194d1",
               BookTitle.GATES,
               "",
               211,
               "",
               "https://www.dropbox.com/s/itutxuvooshoack/gates.jpg?raw=1",
               "In a Chicago troubled by the war against the Alliance, Louisa and her best friend, Maddie, disguised as her twin sister, are sent to the exclusive Country Manor School, where they are cut off from the outside world and learn survival skills."
            );

            var bookWage = new Book(
               "3a0a34f5-8fa3-e3fd-07b6-cb825dc6868b",
               BookTitle.WAGE,
               "Ending Subminimum Pay in America",
               256,
               "",
               "https://www.dropbox.com/s/ymc4c7z0uaar3fv/wage.jpg?raw=1",
               "From the author of the acclaimed Behind the Kitchen Door, a powerful examination of how the subminimum wage and the tipping system exploit society's most vulnerable \u003c/p\u003e \u003cp\u003e\"No one has done more to move forward the rights of food and restaurant workers than Saru Jayaraman.\" --Mark Bittman, author of The Kitchen Matrix and A Bone to Pick\u003c/p\u003e \u003cp\u003eBefore the COVID-19 pandemic devastated the country, more than six million people earned their living as tipped workers in the service industry. They served us in cafes and restaurants, they delivered food to our homes, they drove us wherever we wanted to go, and they worked in nail salons for as little as $2.13 an hour--the federal tipped minimum wage since 1991--leaving them with next to nothing to get by.\u003c/p\u003e \u003cp\u003eThese workers, unsurprisingly, were among the most vulnerable workers during the pandemic. As businesses across the country closed down or drastically scaled back their services, hundreds of thousands lost their jobs. As in many other areas, the pandemic exposed the inadequacies of the nation's social safety net and minimum-wage standards.\u003c/p\u003e \u003cp\u003eOne of New York magazine's \"Influentials\" of New York City, one of CNN's Visionary Women in 2014, and a White House Champion of Change in 2014, Saru Jayaraman is a nationally acclaimed restaurant activist and the author of the bestselling Behind the Kitchen Door. In her new book, One Fair Wage, Jayaraman shines a light on these workers, illustrating how the people left out of the fight for a fair minimum wage are society's most marginalized: people of color, many of them immigrants; women, who form the majority of tipped workers; disabled workers; incarcerated workers; and youth workers. They epitomize the direction of our whole economy, reflecting the precariousness and instability that is increasingly the lot of American labor."
            );

            var bookThings = new Book(
               "3a0a34f5-8fa3-3f4a-a209-439111019526",
               BookTitle.THINGS,
               "Building a Business When There Are No Easy Answers",
               304,
               "",
               "https://www.dropbox.com/s/t1lsa9fk248jk2b/things.jpg?raw=1",
               "Ben Horowitz, cofounder of Andreessen Horowitz and one of Silicon Valley's most respected and experienced entrepreneurs, offers essential advice on building and running a startup—practical wisdom for managing the toughest problems business school doesn’t cover, based on his popular ben’s blog.\u003c/p\u003e\u003cp\u003eWhile many people talk about how great it is to start a business, very few are honest about how difficult it is to run one. Ben Horowitz analyzes the problems that confront leaders every day, sharing the insights he’s gained developing, managing, selling, buying, investing in, and supervising technology companies. A lifelong rap fanatic, he amplifies business lessons with lyrics from his favorite songs, telling it straight about everything from firing friends to poaching competitors, cultivating and sustaining a CEO mentality to knowing the right time to cash in.\u003c/p\u003e\u003cp\u003eFilled with his trademark humor and straight talk, The Hard Thing About Hard Things is invaluable for veteran entrepreneurs as well as those aspiring to their own new ventures, drawing from Horowitz's personal and often humbling experiences."
            );

            var bookTimes = new Book(
               "3a0a34f5-8fa3-665e-c58c-6992dda618b1",
               BookTitle.TIMES,
               "Better Answers to Our Biggest Problems",
               416,
               "",
               "https://www.dropbox.com/s/jh174ito54sdh9f/times.jpg?raw=1",
               "FROM THE WINNERS OF THE 2019 NOBEL PRIZE IN ECONOMICS\u003cbr\u003e\u003c/b\u003e\u003cbr\u003e\u003cb\u003e'Wonderfully refreshing . . . A must read' Thomas Piketty \u003c/b\u003e \u003cbr\u003e\u003cbr\u003eIn this revolutionary book, prize-winning economists Abhijit V. Banerjee and Esther Duflo show how economics, when done right, can help us solve the thorniest social and political problems of our day. From immigration to inequality, slowing growth to accelerating climate change, we have the resources to address the challenges we face but we are so often blinded by ideology.\u003cbr\u003e\u003cbr\u003eOriginal, provocative and urgent,\u003ci\u003e Good Economics for Hard Times\u003c/i\u003e offers the new thinking that we need. It builds on cutting-edge research in economics - and years of exploring the most effective solutions to alleviate extreme poverty - to make a persuasive case for an intelligent interventionism and a society built on compassion and respect. A much-needed antidote to polarized discourse, this book shines a light to help us appreciate and understand our precariously balanced world."
            );

            await _bookRepository.InsertManyAsync(
                new[] { bookStone, bookPrince, bookGates, bookWage, bookThings, bookTimes }
            );
        }

        public async Task SeedUserReadingPackagesAsync()
        {
            var userBac = await _userRepository.FindAsync(UserBac.ID);
            // var userTuan = await _userRepository.FindByUsernameAsync(UserTuan.USERNAME);

            var readingPackageBasic = await _readingPackageRepository.FindByNameAsync(ReadingPackageName.BASIC);
            // var readingPackageStandard = await _readingPackageRepository.FindByNameAsync(ReadingPackageName.STANDARD);

            var userBacReadingPackage = new UserReadingPackage(
                _guidGenerator.Create(),
                userBac.Id,
                readingPackageBasic.Id,
                DateTime.Now,
                TimeSpan.Parse(readingPackageBasic.Duration)
            );

            // var userTuanReadingPackage = new UserReadingPackage(
            //     _guidGenerator.Create(),
            //     userTuan.Id,
            //     readingPackageStandard.Id,
            //     DateTime.Now,
            //     TimeSpan.Parse(readingPackageBasic.Duration)
            // );

            userBac.Packages.Add(userBacReadingPackage);
            // userTuan.Packages.Add(userTuanReadingPackage);

            await _userRepository.UpdateAsync(userBac);
            // await _userRepository.UpdateAsync(userTuan);
        }

        // public async Task SeedUserHistoriesAsync()
        // {
        //     Random random = new Random();

        //     var userBac = await _userRepository.FindByUsernameAsync(UserBac.USERNAME);
        //     var userTuan = await _userRepository.FindByUsernameAsync(UserTuan.USERNAME);

        //     var userBacHistories = Enumerable.Range(1, 30).Select(
        //         x => new UserHistory(
        //             _guidGenerator.Create(),
        //             userBac.Id,
        //             DateTime.Now.Subtract(TimeSpan.FromDays(x)),
        //             new TimeSpan(0, random.Next(5, 59), 0)
        //         )
        //     ).ToList();

        //     var userTuanHistories = Enumerable.Range(1, 30).Select(
        //         x => new UserHistory(
        //             _guidGenerator.Create(),
        //             userTuan.Id,
        //             DateTime.Now.Subtract(TimeSpan.FromDays(x)),
        //             new TimeSpan(0, random.Next(5, 59), 0)
        //         )
        //     ).ToList();

        //     userBac.Histories.AddRange(userBacHistories);
        //     userTuan.Histories.AddRange(userTuanHistories);

        //     await _userRepository.UpdateAsync(userBac);
        //     await _userRepository.UpdateAsync(userTuan);
        // }

        // public async Task SeedUserLibrariesAsync()
        // {
        //     var userBac = await _userRepository.FindByUsernameAsync(UserBac.USERNAME);
        //     var userTuan = await _userRepository.FindByUsernameAsync(UserTuan.USERNAME);

        //     var bookStone = await _bookRepository.FindByTitleAsync(BookTitle.STONE);

        //     var bookGates = await _bookRepository.FindByTitleAsync(BookTitle.GATES);

        //     var bookPrince = await _bookRepository.FindByTitleAsync(BookTitle.PRINCE);

        //     userBac.UserLibraries.AddRange(new List<UserLibrary> {
        //         new UserLibrary(
        //             _guidGenerator.Create(),
        //             userBac.Id,
        //             bookStone.Id,
        //             true,
        //             true,
        //             10,
        //             DateTime.Now
        //         ),
        //         new UserLibrary(
        //             _guidGenerator.Create(),
        //             userBac.Id,
        //             bookGates.Id,
        //             false,
        //             true,
        //             29,
        //             DateTime.Now
        //         ),
        //         new UserLibrary(
        //             _guidGenerator.Create(),
        //             userBac.Id,
        //             bookPrince.Id,
        //             true,
        //             false,
        //             0,
        //             null
        //         )
        //     });

        //     userTuan.UserLibraries.AddRange(new List<UserLibrary> {
        //         new UserLibrary(
        //             _guidGenerator.Create(),
        //             userTuan.Id,
        //             bookStone.Id,
        //             true,
        //             true,
        //             10,
        //             DateTime.Now
        //         ),
        //         new UserLibrary(
        //             _guidGenerator.Create(),
        //             userTuan.Id,
        //             bookGates.Id,
        //             false,
        //             true,
        //             29,
        //             DateTime.Now
        //         ),
        //         new UserLibrary(
        //             _guidGenerator.Create(),
        //             userTuan.Id,
        //             bookPrince.Id,
        //             true,
        //             false,
        //             0,
        //             null
        //         )
        //     });

        //     await _userRepository.UpdateAsync(userBac);
        //     await _userRepository.UpdateAsync(userTuan);
        // }

        // public async Task SeedHighlightsAsync()
        // {
        //     var user = await _userRepository.FindByUsernameAsync(UserBac.USERNAME);

        //     var book = await _bookRepository.FindByTitleAsync(BookTitle.STONE);

        //     var highlights = Enumerable.Range(1, 2).Select(
        //         x => new Highlight(
        //             user.Id,
        //             book.Id,
        //             "",
        //             DateTime.Now.Subtract(TimeSpan.FromDays(x)),
        //             "highlight_blue",
        //             0,
        //             "",
        //             "",
        //             _guidGenerator.Create().ToString(),
        //             "this is a note"
        //             )
        //     ).ToList();

        //     user.Highlights.AddRange(highlights);

        //     await _userRepository.UpdateAsync(user);
        // }

        public async Task SeedBookWithAuthorsAsync()
        {
            // Books
            var bookStone = await _bookRepository.FindByTitleAsync(BookTitle.STONE);
            var bookPrince = await _bookRepository.FindByTitleAsync(BookTitle.PRINCE);
            var bookGates = await _bookRepository.FindByTitleAsync(BookTitle.GATES);
            var bookWage = await _bookRepository.FindByTitleAsync(BookTitle.WAGE);
            var bookThings = await _bookRepository.FindByTitleAsync(BookTitle.THINGS);
            var bookTimes = await _bookRepository.FindByTitleAsync(BookTitle.TIMES);

            // Authors
            var authorRowling = await _authorRepository.FindByNameAsync(AuthorName.ROWLING);
            var authorGray = await _authorRepository.FindByNameAsync(AuthorName.GRAY);
            var authorReyes = await _authorRepository.FindByNameAsync(AuthorName.REYES);
            var authorJarayaman = await _authorRepository.FindByNameAsync(AuthorName.JAYARAMAN);
            var authorHorowitz = await _authorRepository.FindByNameAsync(AuthorName.HOROWITZ);
            var authorBanerjee = await _authorRepository.FindByNameAsync(AuthorName.BANERJEE);
            var authorDuflo = await _authorRepository.FindByNameAsync(AuthorName.DUFLO);

            //
            bookStone.BookWithAuthors.AddRange(new[]
                {
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookStone.Id,
                        authorRowling.Id
                    )
                }
            );

            bookPrince.BookWithAuthors.AddRange(new[]
                {
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookPrince.Id,
                        authorRowling.Id
                    )
                }
            );

            bookGates.BookWithAuthors.AddRange(new[]
                {
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookGates.Id,
                        authorGray.Id
                    )
                }
            );

            bookWage.BookWithAuthors.AddRange(new[]
                {
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookWage.Id,
                        authorReyes.Id
                    ),

                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookWage.Id,
                        authorJarayaman.Id
                    )
                }
            );

            bookThings.BookWithAuthors.AddRange(new[]
                {
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookThings.Id,
                        authorHorowitz.Id
                    )
                }
            );

            bookTimes.BookWithAuthors.AddRange(new[]
                {
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookTimes.Id,
                        authorBanerjee.Id
                    ),
                    new BookWithAuthor(
                        _guidGenerator.Create(),
                        bookTimes.Id,
                        authorDuflo.Id
                    )
                }
            );

            //
            await _bookRepository.UpdateAsync(bookStone);
            await _bookRepository.UpdateAsync(bookPrince);
            await _bookRepository.UpdateAsync(bookGates);
            await _bookRepository.UpdateAsync(bookWage);
            await _bookRepository.UpdateAsync(bookThings);
            await _bookRepository.UpdateAsync(bookTimes);
        }

        public async Task SeedBookWithCategoriesAsync()
        {
            // Books
            var bookStone = await _bookRepository.FindByTitleAsync(BookTitle.STONE);
            var bookPrince = await _bookRepository.FindByTitleAsync(BookTitle.PRINCE);
            var bookGates = await _bookRepository.FindByTitleAsync(BookTitle.GATES);
            var bookWage = await _bookRepository.FindByTitleAsync(BookTitle.WAGE);
            var bookThings = await _bookRepository.FindByTitleAsync(BookTitle.THINGS);
            var bookTimes = await _bookRepository.FindByTitleAsync(BookTitle.TIMES);

            // Categories
            var categoryStories = await _categoryRepository.FindByNameAsync(CategoryName.STORIES);
            var categoryFiction = await _categoryRepository.FindByNameAsync(CategoryName.FICTION);
            var categoryBusiness = await _categoryRepository.FindByNameAsync(CategoryName.BUSINESS);
            var categoryEconomy = await _categoryRepository.FindByNameAsync(CategoryName.ECONOMY);

            //
            bookStone.BookWithCategories.AddRange(new[]
                {
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookStone.Id,
                        categoryStories.Id
                    ),
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookStone.Id,
                        categoryFiction.Id
                    ),
                }
            );

            bookPrince.BookWithCategories.AddRange(new[]
                {
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookPrince.Id,
                        categoryStories.Id
                    ),
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookPrince.Id,
                        categoryFiction.Id
                    ),
                }
            );

            bookGates.BookWithCategories.AddRange(new[]
                {
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookGates.Id,
                        categoryFiction.Id
                    ),
                }
            );

            bookWage.BookWithCategories.AddRange(new[]
                {
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookWage.Id,
                        categoryBusiness.Id
                    ),
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookWage.Id,
                        categoryEconomy.Id
                    )
                }
            );

            bookThings.BookWithCategories.AddRange(new[]
                {
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookThings.Id,
                        categoryBusiness.Id
                    )
                }
            );

            bookTimes.BookWithCategories.AddRange(new[]
                {
                    new BookWithCategory(
                        _guidGenerator.Create(),
                        bookTimes.Id,
                        categoryEconomy.Id
                    )
                }
            );

            //
            await _bookRepository.UpdateAsync(bookStone);
            await _bookRepository.UpdateAsync(bookPrince);
            await _bookRepository.UpdateAsync(bookGates);
            await _bookRepository.UpdateAsync(bookWage);
            await _bookRepository.UpdateAsync(bookThings);
            await _bookRepository.UpdateAsync(bookTimes);
        }
    }
}

public enum Option
{
    InitialPrimary,
    InitialSecondary
}

public class UserBac
{
    public static readonly string ID = "kqx9ZPD4pgM6N0rSdFAhVzOJTs83";
}

public class UserTuan
{
    public static readonly string ID = "6h38NGTh5lPZMTB0U83Rv0WUE1A2";
}

public class ReadingPackageName
{
    public static readonly string BASIC = "Gói Đọc Sách Tháng";
    public static readonly string STANDARD = "Gói Đọc Sách 3 Tháng";
    public static readonly string ECONOMICS = "Gói Đọc Sách Năm";
}

public class AuthorName
{
    public static readonly string ROWLING = "J. K. Rowling";
    public static readonly string GRAY = "Eva Gray";
    public static readonly string REYES = "Teofilo Reyes";
    public static readonly string JAYARAMAN = "Saru Jayaraman";
    public static readonly string HOROWITZ = "Ben Horowitz";
    public static readonly string BANERJEE = "Abhijit V. Banerjee";
    public static readonly string DUFLO = "Esther Duflo";
}

public class CategoryName
{
    public static readonly string STORIES = "Children's stories";
    public static readonly string FICTION = "Juvenile Fiction";
    public static readonly string BUSINESS = "Business";
    public static readonly string ECONOMY = "Economy";
}

public class BookTitle
{
    public static readonly string STONE = "Harry Potter and the Philosopher's Stone";
    public static readonly string PRINCE = "Harry Potter and the Half-blood Prince";
    public static readonly string GATES = "Behind the Gates";
    public static readonly string WAGE = "One Fair Wage";
    public static readonly string THINGS = "The Hard Thing About Hard Things";
    public static readonly string TIMES = "Good Economics for Hard Times";
}