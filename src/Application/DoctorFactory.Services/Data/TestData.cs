using DoctorFactory.Domain.Entities.Base;
using DoctorFactory.Domain.Entities.Blog;
using DoctorFactory.Domain.Entities.Course;
using DoctorFactory.Domain.Shared;

namespace DoctorFactory.Services.Data;

/// <summary> Test data. </summary>
internal static class TestData
{
    const string shortDescription = "Use XD to get a job in UI Design, User Interface, User Experience design, UX design & Web Design";

    const string description = "Phasellus enim magna, varius et commodo ut, ultricies vitae velit. ";
    //+ 
    //                       "Ut nulla tellus, eleifend euismod pellentesque vel, sagittis vel justo. " +
    //                       "In libero urna, venenatis sit amet ornare non, suscipit nec risus. Sed consequat justo non mauris pretium at tempor justo sodales. " +
    //                       "Quisque tincidunt laoreet malesuada. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur." +
    //                       "This course is aimed at people interested in UI/UX Design. We’ll start from the very beginning and work all the way through, " +
    //                       "step by step. If you already have some UI/UX Design experience but want to get up to speed using Adobe XD then this course is perfect for you too!" +
    //                       "First, we will go over the differences between UX and UI Design. We will look at what our brief for this real-world project is, then we will learn about " +
    //                       "low-fidelity wireframes and how to make use of existing UI design kits. ";

    #region Course.

    public static IEnumerable<CourseCategory> CourseCategories { get; set; }

    public static IEnumerable<Course> Courses { get; set; }

    #endregion

    #region Blog.

    public static IEnumerable<BlogCategory> BlogCategories { get; set; }

    public static IEnumerable<BlogPost> BlogPosts { get; set; }

    #endregion

    static TestData()
    {
        var random = new Random();

        #region Course data.

        var instructors = new List<Instructor> {
            new() { Id = 0, Name = "John Doe", Ocupation = "Software Engineer", About = "Experienced developer with a passion for teaching." },
            new() { Id = 0, Name = "John Doe", Ocupation = "Software Engineer", About = "Experienced developer with a passion for teaching." }
        };

        var categories = new CourseCategory[]
        {
            new() { Id = 0, Name = "Farmacie" },
            new() { Id = 0, Name = "Medicina generala" },
            new() { Id = 0, Name = "Medicina dentara" }
        };
        CourseCategories = categories;
        
        #region Requirements.

        var requirements1 = new List<CourseRequirement>
        {
            new() { Id = 0, Content = "No previous Adobe XD skills are needed." },
            new() { Id = 0, Content = "No previous design experience is needed." },
            new() { Id = 0, Content = "You will need a copy of Adobe XD 2019 or above. A free trial can be downloaded from Adobe." }
        };

        var requirements2 = new List<CourseRequirement>
        {
            new() { Id = 0, Content = "2 No previous Adobe XD skills are needed." },
            new() { Id = 0, Content = "2 No previous design experience is needed." },
            new() { Id = 0, Content = "2 You will need a copy of Adobe XD 2019 or above. A free trial can be downloaded from Adobe." }
        };

        #endregion

        #region Goals.

        var goals1 = new List<CourseGoal>
        {
            new() { Id = 0, Course = null, Content = "Become a UX designer." },
            new() { Id = 0, Course = null, Content = "Create quick wireframes." },
            new() { Id = 0, Course = null, Content = "Build & test a full website design." },
            new() { Id = 0, Course = null, Content = "You will be able to add UX designer to your CV." },
            new() { Id = 0, Course = null, Content = "You will be able to create beautiful, realistic looking mockups." }
        };

        var goals2 = new List<CourseGoal>
        {
            new() { Id = 0, Course = null, Content = "Become a UX designer." },
            new() { Id = 0, Course = null, Content = "Create quick wireframes." },
            new() { Id = 0, Course = null, Content = "Build & test a full website design." },
            new() { Id = 0, Course = null, Content = "You will be able to add UX designer to your CV." },
            new() { Id = 0, Course = null, Content = "You will be able to create beautiful, realistic looking mockups." }
        };

        #endregion

        #region Reviews.

        var reviews1 = new List<CourseReview>
        {
            new() { Id = 0, Content = "1 No previous Adobe XD skills are needed.", Name = "Course review name 1", Rate = 3, AuthorId = 0 },
            new() { Id = 0, Content = "1 No previous design experience is needed.", Name = "Course review name 2", Rate = 3, AuthorId = 0 },
            new() { Id = 0, Content = "1 You will need a copy of Adobe XD 2019 or above. A free trial can be downloaded from Adobe.", Name = "Course review name 3", Rate = 3, AuthorId = 0 },
        };

        var reviews2 = new List<CourseReview>
        {
            new() { Id = 0, Content = "2 No previous Adobe XD skills are needed.", Name = "Course review name 1", Rate = 3, AuthorId = 0 },
            new() { Id = 0, Content = "2 No previous design experience is needed.", Name = "Course review name 2", Rate = 3, AuthorId = 0 },
            new() { Id = 0, Content = "2 You will need a copy of Adobe XD 2019 or above. A free trial can be downloaded from Adobe.", Name = "Course review name 3", Rate = 3, AuthorId = 0 },
        };

        #endregion

        #region Courses.

        var course1 = new Course
        {
            Id = 0,
            Name = "Course name - 1",
            Category = categories[0],
            Instructors = instructors,
            ShortDescription = shortDescription + " Course 1",
            Description = " Course 1" + description,
            Image = string.Empty,
            SkillLevel = (SkillLevel)random.Next(Enum.GetValues(typeof(SkillLevel)).Length),
            DateCreation = DateTimeOffset.Now.AddDays(random.Next(5, 150)),
            Enrolled = random.Next(0, 100),
            Price = random.Next(0, 100),
            Discount = random.Next(0, 100),
            Content = null,
            Goals = goals1,
            Requirements = requirements1,
            Reviews = reviews1,
        };

        var course2 = new Course
        {
            Id = 0,
            Name = "Course name - 2",
            Category = categories[1],
            Instructors = instructors,
            ShortDescription = shortDescription + " Course 2",
            Description = " Course 2" + description,
            Image = string.Empty,
            SkillLevel = (SkillLevel)random.Next(Enum.GetValues(typeof(SkillLevel)).Length),
            DateCreation = DateTimeOffset.Now.AddDays(random.Next(5, 150)),
            Enrolled = random.Next(0, 100),
            Price = random.Next(0, 100),
            Discount = random.Next(0, 100),
            Content = null,
            Goals = goals2,
            Requirements = requirements2,
            Reviews = reviews2,
        };

        #region Course content.

        #region Lessons

        #region Lesson 1.

        var lesson1 = new Lesson
        {
            Id = 0,
            Name = "Course lesson 1",
            Content = null!,
            Flashcards = null!,
            Quizzes = null!,
            Duration = random.NextDouble() * (2 - 8) + 2,
            IsAvaible = true
        };

        var lesson2 = new Lesson
        {
            Id = 0,
            Name = "Course lesson 2",
            Content = null!,
            Flashcards = null!,
            Quizzes = null!,
            Duration = random.NextDouble() * (2 - 8) + 2,
            IsAvaible = true
        };

        #region Lesson content.

        var lessonContent1 = new List<LessonContent>
        {
            new() { Id = 0, Name = "Lesson content name 1", Text = "Lesson content text 1", Video = "Lesson content video 1"},
            new() { Id = 0, Name = "Lesson content name 2", Text = "Lesson content text 2", Video = "Lesson content video 2"},
        };

        var lessonContent2 = new List<LessonContent>
        {
            new() { Id = 0, Name = "Lesson content name 1", Text = "Lesson content text 1", Video = "Lesson content video 1"},
            new() { Id = 0, Name = "Lesson content name 2", Text = "Lesson content text 2", Video = "Lesson content video 2"},
        };

        lesson1.Content = lessonContent1;
        lesson2.Content = lessonContent2;

        #endregion

        #region Flashcard

        var flashcard1 = new Flashcard
        {
            Id = 0,
            Name = "Flashcard name 1",
            Lesson = lesson1,
            Question = "Flashcard question 1",
            Answer = "Flashcard answer 1"
        };

        var flashcard2 = new Flashcard
        {
            Id = 0,
            Name = "Flashcard name 2",
            Lesson = lesson1,
            Question = "Flashcard question 2",
            Answer = "Flashcard answer 2"
        };

        var flashcard3 = new Flashcard
        {
            Id = 0,
            Name = "Flashcard name 1",
            Lesson = lesson2,
            Question = "Flashcard question 1",
            Answer = "Flashcard answer 1"
        };

        var flashcard4 = new Flashcard
        {
            Id = 0,
            Name = "Flashcard name 2",
            Lesson = lesson2,
            Question = "Flashcard question 2",
            Answer = "Flashcard answer 2"
        };

        lesson1.Flashcards = new List<Flashcard> { flashcard1, flashcard2 };
        lesson2.Flashcards = new List<Flashcard> { flashcard3, flashcard4 };

        #endregion

        #region Lesson Quizes.

        var quiz1 = new Quiz
        {
            Id = 0,
            Question = "Quiz question - 1",
            Answers = null!,
        };

        quiz1.Answers = new List<QuizAnswer>
        {
            new() { Id = 0, Answer = "Quiz answer 1", IsRight = true, Quiz = quiz1 },
            new() { Id = 0, Answer = "Quiz answer 2", IsRight = false, Quiz = quiz1 },
            new() { Id = 0, Answer = "Quiz answer 3", IsRight = false, Quiz = quiz1 },
        };

        var quiz2 = new Quiz
        {
            Id = 0,
            Question = "Quiz question - 1",
            Answers = null!,
        };

        quiz2.Answers = new List<QuizAnswer>
        {
            new() { Id = 0, Answer = "Quiz answer 4", IsRight = true, Quiz = quiz2 },
            new() { Id = 0, Answer = "Quiz answer 5", IsRight = false, Quiz = quiz2 },
            new() { Id = 0, Answer = "Quiz answer 6", IsRight = true, Quiz = quiz2 },
        };

        lesson1.Quizzes = new List<Quiz> { quiz1, quiz2 };
        lesson2.Quizzes = new List<Quiz> { quiz1, quiz2 };

        #endregion

        #endregion

        #endregion

        course1.Content = new List<Lesson> { lesson1 };
        course2.Content = new List<Lesson> { lesson2 };

        #endregion

        #endregion

        Courses = new List<Course> { course1, course2 };

        #endregion

        #region Blog data.

        var blogAuthors = new Author[]
        {
            new() { Id = 0, Name = "Blog author 1", Ocupation = "Blog author ocupation 1", About = "Blog author about 1" },
            new() { Id = 0, Name = "Blog author 2", Ocupation = "Blog author ocupation 2", About = "Blog author about 2" },
            new() { Id = 0, Name = "Blog author 3", Ocupation = "Blog author ocupation 3", About = "Blog author about 3" }
        };

        var blogCategories = new BlogCategory[]
        {
            new() { Id = 0, Name = "Blog category farmacie" },
            new() { Id = 0, Name = "Blog category Medicina generala" },
            new() { Id = 0, Name = "Blog category Medicina dentara" }
        };
        BlogCategories = blogCategories;

        var blogPost1 = new BlogPost
        {
            Id = 0,
            Category = blogCategories[0],
            BlogPostAuthor = blogAuthors[0],
            Title = "Blog post title 1",
            Date = DateTimeOffset.Now.AddDays(random.Next(5, 150)),
            DateUpdate = null,
            MainImage = string.Empty,
            Content = "Blog post content 1",
            Tags = null!,
            Reviews = null,
            IsDeleted = false
        };

        var blogPost2 = new BlogPost
        {
            Id = 0,
            Category = blogCategories[1],
            BlogPostAuthor = blogAuthors[1],
            Title = "Blog post title 2",
            Date = DateTimeOffset.Now.AddDays(random.Next(5, 150)),
            DateUpdate = null,
            MainImage = string.Empty,
            Content = "Blog post content 2",
            Tags = null!,
            Reviews = null,
            IsDeleted = false
        };

        var blogPost3 = new BlogPost
        {
            Id = 0,
            Category = blogCategories[2],
            BlogPostAuthor = blogAuthors[2],
            Title = "Blog post title 3",
            Date = DateTimeOffset.Now.AddDays(random.Next(5, 150)),
            DateUpdate = null,
            MainImage = string.Empty,
            Content = "Blog post content 3",
            Tags = null!,
            Reviews = null,
            IsDeleted = false
        };

        #region Blog post tags.

        var blogTag1 = new Tag
        {
            Id = 0,
            Name = "Blog tag 1",
            Posts = new List<BlogPost> { blogPost1 }
        };

        var blogTag2 = new Tag
        {
            Id = 0,
            Name = "Blog tag 2",
            Posts = new List<BlogPost> { blogPost1 }
        };

        var blogTag3 = new Tag
        {
            Id = 0,
            Name = "Blog tag 3",
            Posts = new List<BlogPost> { blogPost2 }
        };

        var blogTag4 = new Tag
        {
            Id = 0,
            Name = "Blog tag 4",
            Posts = new List<BlogPost> { blogPost2 }
        };

        var blogTag5 = new Tag
        {
            Id = 0,
            Name = "Blog tag 5",
            Posts = new List<BlogPost> { blogPost3 }
        };

        var blogTag6 = new Tag
        {
            Id = 0,
            Name = "Blog tag 6",
            Posts = new List<BlogPost> { blogPost3 }
        };

        blogPost1.Tags = new List<Tag> { blogTag1, blogTag2, blogTag3 };
        blogPost2.Tags = new List<Tag> { blogTag2, blogTag3, blogTag4 };
        blogPost3.Tags = new List<Tag> { blogTag5, blogTag6, blogTag1, blogTag2 };

        #endregion

        #region Blog post reviews.

        var blogReview1 = new BlogReview
        {
            Id = 0,
            Post = blogPost1,
            Content = "Blog review content 1",
            Name = "Blog review name 1",
            Rate = 3,
            AuthorId = 0
        };

        var blogReview2 = new BlogReview
        {
            Id = 0,
            Post = blogPost1,
            Content = "Blog review content 2",
            Name = "Blog review name 2",
            Rate = 4,
            AuthorId = 0
        };

        var blogReview3 = new BlogReview
        {
            Id = 0,
            Post = blogPost1,
            Content = "Blog review content 3",
            Name = "Blog review name 3",
            Rate = 1,
            AuthorId = 0
        };

        var blogReview4 = new BlogReview
        {
            Id = 0,
            Post = blogPost2,
            Content = "Blog review content 4",
            Name = "Blog review name 4",
            Rate = 5,
            AuthorId = 0
        };

        var blogReview5 = new BlogReview
        {
            Id = 0,
            Post = blogPost2,
            Content = "Blog review content 5",
            Name = "Blog review name 5",
            Rate = 3,
            AuthorId = 0
        };

        var blogReview6 = new BlogReview
        {
            Id = 0,
            Post = blogPost2,
            Content = "Blog review content 6",
            Name = "Blog review name 6",
            Rate = 4,
            AuthorId = 0
        };

        var blogReview7 = new BlogReview
        {
            Id = 0,
            Post = blogPost3,
            Content = "Blog review content 7",
            Name = "Blog review name 7",
            Rate = 1,
            AuthorId = 0
        };

        var blogReview8 = new BlogReview
        {
            Id = 0,
            Post = blogPost3,
            Content = "Blog review content 8",
            Name = "Blog review name 8",
            Rate = 5,
            AuthorId = 0
        };

        var blogReview9 = new BlogReview
        {
            Id = 90,
            Post = blogPost3,
            Content = "Blog review content 9",
            Name = "Blog review name 9",
            Rate = 5,
            AuthorId = 0
        };

        blogPost1.Reviews = new List<BlogReview> { blogReview1, blogReview2, blogReview3 };
        blogPost2.Reviews = new List<BlogReview> { blogReview4, blogReview5, blogReview6 };
        blogPost3.Reviews = new List<BlogReview> { blogReview7, blogReview8, blogReview9 };

        #endregion

        BlogPosts = new List<BlogPost> { blogPost1, blogPost2, blogPost3 };

        #endregion
    }
}
