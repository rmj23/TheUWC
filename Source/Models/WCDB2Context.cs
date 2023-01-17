namespace Source.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WCDB2Context : DbContext
    {
        public WCDB2Context()
            : base("name=WCDB2Context")
        {
        }

        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AvatarImg> AvatarImgs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChartLookup> ChartLookups { get; set; }
        public virtual DbSet<ChartLookup2> ChartLookup2 { get; set; }
        public virtual DbSet<ClassLevel> ClassLevels { get; set; }
        public virtual DbSet<cmsDistrictInfo> cmsDistrictInfoes { get; set; }
        public virtual DbSet<cmsSchoolInfo> cmsSchoolInfoes { get; set; }
        public virtual DbSet<CommentBank> CommentBanks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ConceptsPrint> ConceptsPrints { get; set; }
        public virtual DbSet<ConceptsPrintLookup> ConceptsPrintLookups { get; set; }
        public virtual DbSet<ConferenceType> ConferenceTypes { get; set; }
        public virtual DbSet<ContactRequest> ContactRequests { get; set; }
        public virtual DbSet<ContinuumData> ContinuumDatas { get; set; }
        public virtual DbSet<Convention> Conventions { get; set; }
        public virtual DbSet<ConventionsLookup> ConventionsLookups { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSchedule> CourseSchedules { get; set; }
        public virtual DbSet<CourseSemester> CourseSemesters { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<engEngagement> engEngagements { get; set; }
        public virtual DbSet<engKeyword> engKeywords { get; set; }
        public virtual DbSet<engModule> engModules { get; set; }
        public virtual DbSet<engSubtype> engSubtypes { get; set; }
        public virtual DbSet<engSubtypeGrade> engSubtypeGrades { get; set; }
        public virtual DbSet<engValidSubtype> engValidSubtypes { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<EvaluationPeriod> EvaluationPeriods { get; set; }
        public virtual DbSet<EvaluationScore> EvaluationScores { get; set; }
        public virtual DbSet<Glossary> Glossaries { get; set; }
        public virtual DbSet<GoalsByClass> GoalsByClasses { get; set; }
        public virtual DbSet<GoalsIndividualStudent> GoalsIndividualStudents { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradeNumericScoreLevel> GradeNumericScoreLevels { get; set; }
        public virtual DbSet<GuidelineUpdateCompletion> GuidelineUpdateCompletions { get; set; }
        public virtual DbSet<IdeasContent> IdeasContents { get; set; }
        public virtual DbSet<IdeasContentLookup> IdeasContentLookups { get; set; }
        public virtual DbSet<IPAddress> IPAddresses { get; set; }
        public virtual DbSet<IPAddressCity> IPAddressCities { get; set; }
        public virtual DbSet<IPAdress> IPAdresses { get; set; }
        public virtual DbSet<LessonPlan> LessonPlans { get; set; }
        public virtual DbSet<NumericScoreLevel> NumericScoreLevels { get; set; }
        public virtual DbSet<OrganizationStructure> OrganizationStructures { get; set; }
        public virtual DbSet<OrgStructureLookup> OrgStructureLookups { get; set; }
        public virtual DbSet<PageEvent> PageEvents { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<PaperComment> PaperComments { get; set; }
        public virtual DbSet<PaperType> PaperTypes { get; set; }
        public virtual DbSet<PaperTypeSpecificGuidelineUpdateCompletion> PaperTypeSpecificGuidelineUpdateCompletions { get; set; }
        public virtual DbSet<ParentStudent> ParentStudents { get; set; }
        public virtual DbSet<PointWinner> PointWinners { get; set; }
        public virtual DbSet<ProficiencyLevel> ProficiencyLevels { get; set; }
        public virtual DbSet<ProficiencyType> ProficiencyTypes { get; set; }
        public virtual DbSet<ptsActivityScore> ptsActivityScores { get; set; }
        public virtual DbSet<ptsUserActivityScore> ptsUserActivityScores { get; set; }
        public virtual DbSet<Publishing> Publishings { get; set; }
        public virtual DbSet<PublishingLookup> PublishingLookups { get; set; }
        public virtual DbSet<RequiredPoint> RequiredPoints { get; set; }
        public virtual DbSet<Research> Researches { get; set; }
        public virtual DbSet<ResearchLookup> ResearchLookups { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<schoolCode> schoolCodes { get; set; }
        public virtual DbSet<SchoolEvaluation> SchoolEvaluations { get; set; }
        public virtual DbSet<SchoolGrade> SchoolGrades { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }
        public virtual DbSet<SchoolTypeGrade> SchoolTypeGrades { get; set; }
        public virtual DbSet<ScoringLevel> ScoringLevels { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SentenceStructure> SentenceStructures { get; set; }
        public virtual DbSet<SentenceStructureLookup> SentenceStructureLookups { get; set; }
        public virtual DbSet<SessionEvent> SessionEvents { get; set; }
        public virtual DbSet<SitesMonitored> SitesMonitoreds { get; set; }
        public virtual DbSet<SiteVisit> SiteVisits { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<tblError> tblErrors { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherMood> TeacherMoods { get; set; }
        public virtual DbSet<tempDemoReq> tempDemoReqs { get; set; }
        public virtual DbSet<tmsTicket> tmsTickets { get; set; }
        public virtual DbSet<tmsTicketAcknowledged> tmsTicketAcknowledgeds { get; set; }
        public virtual DbSet<tmsTicketAssignee> tmsTicketAssignees { get; set; }
        public virtual DbSet<tmsTicketAssigneeAction> tmsTicketAssigneeActions { get; set; }
        public virtual DbSet<tmsTicketAssigneeHour> tmsTicketAssigneeHours { get; set; }
        public virtual DbSet<tmsTicketNote> tmsTicketNotes { get; set; }
        public virtual DbSet<tmsTicketType> tmsTicketTypes { get; set; }
        public virtual DbSet<tmsType> tmsTypes { get; set; }
        public virtual DbSet<tmsUpdate> tmsUpdates { get; set; }
        public virtual DbSet<tmsUpdateRequest> tmsUpdateRequests { get; set; }
        public virtual DbSet<twcGuideline> twcGuidelines { get; set; }
        public virtual DbSet<twcGuidelineProficiency> twcGuidelineProficiencies { get; set; }
        public virtual DbSet<twcLevel> twcLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ValidEvaluationType> ValidEvaluationTypes { get; set; }
        public virtual DbSet<validGoalTopic> validGoalTopics { get; set; }
        public virtual DbSet<ValidScoreType> ValidScoreTypes { get; set; }
        public virtual DbSet<WebAdminLead> WebAdminLeads { get; set; }
        public virtual DbSet<WordChoice> WordChoices { get; set; }
        public virtual DbSet<WordChoiceLookup> WordChoiceLookups { get; set; }
        public virtual DbSet<WritingGuideline> WritingGuidelines { get; set; }
        public virtual DbSet<writingGuidelineDetail> writingGuidelineDetails { get; set; }
        public virtual DbSet<WritingGuideline1> WritingGuidelines1 { get; set; }
        public virtual DbSet<WritingGuidelinesLookup> WritingGuidelinesLookups { get; set; }
        public virtual DbSet<WritingProcess> WritingProcesses { get; set; }
        public virtual DbSet<WritingProcessLookup> WritingProcessLookups { get; set; }
        public virtual DbSet<WritingRange> WritingRanges { get; set; }
        public virtual DbSet<WritingRangeLookup> WritingRangeLookups { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<forumThread> forumThreads { get; set; }
        public virtual DbSet<forumTopic> forumTopics { get; set; }
        public virtual DbSet<Greeting> Greetings { get; set; }
        public virtual DbSet<NewsandUpdatesText> NewsandUpdatesTexts { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ProficiencyLevelMonthGrade> ProficiencyLevelMonthGrades { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<TeacherDashboardWhatsNew> TeacherDashboardWhatsNews { get; set; }
        public virtual DbSet<TeacherWhatsNew> TeacherWhatsNews { get; set; }
        public virtual DbSet<tmsTicketUpdate1> tmsTicketUpdate1 { get; set; }
        public virtual DbSet<validPaperType> validPaperTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicYear>()
                .Property(e => e.SchoolYear)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.street1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.street2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Schools)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Assignment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AvatarImg>()
                .Property(e => e.imgSrc)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.catDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ChartLookup>()
                .Property(e => e.monthID)
                .IsFixedLength();

            modelBuilder.Entity<ChartLookup2>()
                .Property(e => e.monthID)
                .IsFixedLength();

            modelBuilder.Entity<ClassLevel>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.DistrictCode)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.DistrictName)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.StreetAddress)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.Super)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.AsstSuper)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.CurrCoordinator)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.AccountsPayable)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.ElementarySchools)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.MiddleSchools)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.HighSchools)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<cmsDistrictInfo>()
                .Property(e => e.LicensesPurchased)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.SchoolCode)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.Principal)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.AstPrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.AstPhone)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.LC)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.LCPhone)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.AP)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.APPhone)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.GradeLevels)
                .IsUnicode(false);

            modelBuilder.Entity<cmsSchoolInfo>()
                .Property(e => e.LicensesPurchased)
                .IsUnicode(false);

            modelBuilder.Entity<CommentBank>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Comment1)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ConceptsPrint>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<ConceptsPrint>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ConceptsPrint>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<ConceptsPrint>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ConceptsPrint>()
                .HasMany(e => e.ConceptsPrintLookups)
                .WithOptional(e => e.ConceptsPrint)
                .HasForeignKey(e => e.conceptsID);

            modelBuilder.Entity<ConferenceType>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.StreetNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.StreetName)
                .IsUnicode(false);

            modelBuilder.Entity<ContactRequest>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<ContinuumData>()
                .Property(e => e.Guidelines)
                .IsUnicode(false);

            modelBuilder.Entity<Convention>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<Convention>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Convention>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<Convention>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Convention>()
                .HasMany(e => e.ConventionsLookups)
                .WithOptional(e => e.Convention)
                .HasForeignKey(e => e.conventionsID);

            modelBuilder.Entity<Course>()
                .Property(e => e.courseTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasOptional(e => e.Course1)
                .WithRequired(e => e.Course2);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.GoalsByClasses)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.LessonPlans)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Papers)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentCourses)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseSchedule>()
                .Property(e => e.ScheduleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CourseSchedule>()
                .HasMany(e => e.twcGuidelineProficiencies)
                .WithRequired(e => e.CourseSchedule)
                .HasForeignKey(e => e.ScheduleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<District>()
                .Property(e => e.DistrictName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.SuperintendentName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.SuperintendentEmail)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.SuperintendentPhone)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.AstSuperintendentName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.AstSuperintendentEmail)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.AstSuperintendentPhone)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.CurriculumCoordinatorName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.CurriculumCoordinatorEmail)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.AccountsPayableName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.ElemSchoolNumber)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.MidSchoolNumber)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.HighSchoolNumber)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.LicensesPurchased)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.DistrictAdminName)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.DistrictAdminEmail)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.DistrictAdminPhone)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.AccountsPayableEmail)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.AccountsPayablePhone)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.CurriculumCoordinatorPhone)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.schoolCodes)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Schools)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<engEngagement>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<engEngagement>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<engKeyword>()
                .Property(e => e.Keyword)
                .IsUnicode(false);

            modelBuilder.Entity<engKeyword>()
                .HasMany(e => e.engEngagements)
                .WithMany(e => e.engKeywords)
                .Map(m => m.ToTable("engEngagementKeyword").MapLeftKey("KeywordID").MapRightKey("EngagementID"));

            modelBuilder.Entity<engKeyword>()
                .HasMany(e => e.engModules)
                .WithMany(e => e.engKeywords)
                .Map(m => m.ToTable("engModuleKeyword").MapLeftKey("KeywordID").MapRightKey("ModuleID"));

            modelBuilder.Entity<engKeyword>()
                .HasMany(e => e.engSubtypes)
                .WithMany(e => e.engKeywords)
                .Map(m => m.ToTable("engSubtypeKeyword").MapLeftKey("KeywordID").MapRightKey("SubtypeID"));

            modelBuilder.Entity<engModule>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<engModule>()
                .HasMany(e => e.engSubtypes)
                .WithRequired(e => e.engModule)
                .HasForeignKey(e => e.ModuleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<engSubtype>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<engSubtype>()
                .HasMany(e => e.engEngagements)
                .WithOptional(e => e.engSubtype)
                .HasForeignKey(e => e.SubtypeID);

            modelBuilder.Entity<engSubtype>()
                .HasMany(e => e.engSubtypeGrades)
                .WithOptional(e => e.engSubtype)
                .HasForeignKey(e => e.subtypeID);

            modelBuilder.Entity<engValidSubtype>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<engValidSubtype>()
                .HasMany(e => e.engSubtypes)
                .WithOptional(e => e.engValidSubtype)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.StudentFeedback)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.EvaluationScores)
                .WithRequired(e => e.Evaluation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evaluation>()
                .HasMany(e => e.Papers)
                .WithOptional(e => e.Evaluation)
                .HasForeignKey(e => e.EvaluationID);

            modelBuilder.Entity<EvaluationPeriod>()
                .Property(e => e.evalDescription)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluationPeriod>()
                .HasMany(e => e.twcGuidelineProficiencies)
                .WithRequired(e => e.EvaluationPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EvaluationPeriod>()
                .HasMany(e => e.SchoolEvaluations)
                .WithOptional(e => e.EvaluationPeriod)
                .HasForeignKey(e => e.evaluationID);

            modelBuilder.Entity<EvaluationPeriod>()
                .HasMany(e => e.WritingGuidelinesLookups)
                .WithOptional(e => e.EvaluationPeriod)
                .HasForeignKey(e => e.monthID);

            modelBuilder.Entity<EvaluationScore>()
                .Property(e => e.ScoreData)
                .IsUnicode(false);

            modelBuilder.Entity<Glossary>()
                .Property(e => e.term)
                .IsUnicode(false);

            modelBuilder.Entity<Glossary>()
                .Property(e => e.definition)
                .IsUnicode(false);

            modelBuilder.Entity<GoalsByClass>()
                .Property(e => e.shortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<GoalsByClass>()
                .Property(e => e.fullDescription)
                .IsUnicode(false);

            modelBuilder.Entity<GoalsIndividualStudent>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<GoalsIndividualStudent>()
                .Property(e => e.fullDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .Property(e => e.gradeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .Property(e => e.gradeLetter)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .HasMany(e => e.twcGuidelineProficiencies)
                .WithRequired(e => e.Grade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grade>()
                .HasMany(e => e.SchoolGrades)
                .WithRequired(e => e.Grade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdeasContent>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<IdeasContent>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<IdeasContent>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<IdeasContent>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IdeasContent>()
                .HasMany(e => e.IdeasContentLookups)
                .WithRequired(e => e.IdeasContent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IPAddress>()
                .Property(e => e.ipAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<IPAddress>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<IPAddress>()
                .Property(e => e.organization)
                .IsUnicode(false);

            modelBuilder.Entity<IPAddress>()
                .Property(e => e.isp)
                .IsUnicode(false);

            modelBuilder.Entity<IPAddressCity>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<IPAdress>()
                .Property(e => e.ipAddress)
                .IsUnicode(false);

            modelBuilder.Entity<IPAdress>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<IPAdress>()
                .Property(e => e.organization)
                .IsUnicode(false);

            modelBuilder.Entity<IPAdress>()
                .Property(e => e.isp)
                .IsUnicode(false);

            modelBuilder.Entity<IPAdress>()
                .HasMany(e => e.SessionEvents)
                .WithOptional(e => e.IPAdress)
                .HasForeignKey(e => e.ipID);

            modelBuilder.Entity<LessonPlan>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<LessonPlan>()
                .Property(e => e.LessonPlanTitle)
                .IsUnicode(false);

            modelBuilder.Entity<NumericScoreLevel>()
                .Property(e => e.scoreLevelName)
                .IsUnicode(false);

            modelBuilder.Entity<OrganizationStructure>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<OrganizationStructure>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<OrganizationStructure>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<OrganizationStructure>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OrganizationStructure>()
                .HasMany(e => e.OrgStructureLookups)
                .WithRequired(e => e.OrganizationStructure)
                .HasForeignKey(e => e.orgStructureID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PageEvent>()
                .Property(e => e.startURL)
                .IsUnicode(false);

            modelBuilder.Entity<PageEvent>()
                .HasMany(e => e.PageEvent1)
                .WithOptional(e => e.PageEvent2)
                .HasForeignKey(e => e.prevPageEventID);

            modelBuilder.Entity<Paper>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.PaperTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.HolisticScoreLetter)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.Paper)
                .HasForeignKey(e => e.PaperID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaperComment>()
                .Property(e => e.commentDescription)
                .IsUnicode(false);

            modelBuilder.Entity<PaperType>()
                .Property(e => e.paperType1)
                .IsUnicode(false);

            modelBuilder.Entity<PaperType>()
                .HasMany(e => e.ContinuumDatas)
                .WithRequired(e => e.PaperType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaperType>()
                .HasMany(e => e.twcGuidelines)
                .WithRequired(e => e.PaperType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PointWinner>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<ProficiencyLevel>()
                .Property(e => e.ProficiencyLevel1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProficiencyType>()
                .Property(e => e.Proficiency)
                .IsUnicode(false);

            modelBuilder.Entity<ProficiencyType>()
                .HasMany(e => e.EvaluationScores)
                .WithRequired(e => e.ProficiencyType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ptsActivityScore>()
                .Property(e => e.activityDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ptsActivityScore>()
                .HasMany(e => e.ptsUserActivityScores)
                .WithRequired(e => e.ptsActivityScore)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publishing>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<Publishing>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Publishing>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<Publishing>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RequiredPoint>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<Research>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<Research>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Research>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<Research>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<School>()
                .Property(e => e.schoolName)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.schoolCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.CourseSemesters)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.SchoolGrades)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.schoolCodes)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<schoolCode>()
                .Property(e => e.schoolCode1)
                .IsUnicode(false);

            modelBuilder.Entity<schoolCode>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.schoolCodes)
                .Map(m => m.ToTable("schoolCodesUsed").MapLeftKey("schoolCodeID").MapRightKey("teacherID"));

            modelBuilder.Entity<SchoolType>()
                .Property(e => e.SchoolType1)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolTypeGrade>()
                .HasOptional(e => e.SchoolTypeGrade1)
                .WithRequired(e => e.SchoolTypeGrade2);

            modelBuilder.Entity<ScoringLevel>()
                .Property(e => e.sDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ScoringLevel>()
                .HasMany(e => e.twcGuidelineProficiencies)
                .WithRequired(e => e.ScoringLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScoringLevel>()
                .HasMany(e => e.WritingGuidelinesLookups)
                .WithOptional(e => e.ScoringLevel)
                .HasForeignKey(e => e.levelID);

            modelBuilder.Entity<Semester>()
                .Property(e => e.semesterDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .HasMany(e => e.CourseSemesters)
                .WithRequired(e => e.Semester)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SentenceStructure>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<SentenceStructure>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<SentenceStructure>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<SentenceStructure>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SentenceStructure>()
                .HasMany(e => e.SentenceStructureLookups)
                .WithOptional(e => e.SentenceStructure)
                .HasForeignKey(e => e.sentenceID);

            modelBuilder.Entity<SessionEvent>()
                .HasMany(e => e.PageEvents)
                .WithRequired(e => e.SessionEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SitesMonitored>()
                .Property(e => e.SiteName)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.studentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Papers)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentCourses)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentCourse>()
                .HasMany(e => e.GoalsIndividualStudents)
                .WithRequired(e => e.StudentCourse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Subject1)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.CourseSemesters)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblError>()
                .Property(e => e.errorDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.CommentBanks)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.GoalsByClasses)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.GoalsIndividualStudents)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.LessonPlans)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeacherMood>()
                .Property(e => e.Mood)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherMood>()
                .Property(e => e.MoodVal)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.emailAd)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.school)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.district)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.zipCode)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.licType)
                .IsUnicode(false);

            modelBuilder.Entity<tempDemoReq>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<tmsTicket>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tmsTicket>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tmsTicket>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<tmsTicket>()
                .Property(e => e.Priority)
                .IsUnicode(false);

            modelBuilder.Entity<tmsTicket>()
                .HasMany(e => e.tmsTicketAssignees)
                .WithRequired(e => e.tmsTicket)
                .HasForeignKey(e => e.TicketID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tmsTicket>()
                .HasMany(e => e.tmsTicketTypes)
                .WithRequired(e => e.tmsTicket)
                .HasForeignKey(e => e.TicketID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tmsTicket>()
                .HasMany(e => e.tmsUpdates)
                .WithRequired(e => e.tmsTicket)
                .HasForeignKey(e => e.TicketID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tmsTicket>()
                .HasMany(e => e.tmsUpdateRequests)
                .WithRequired(e => e.tmsTicket)
                .HasForeignKey(e => e.TicketID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tmsTicketAssigneeAction>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<tmsTicketNote>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<tmsType>()
                .Property(e => e.TicketType)
                .IsUnicode(false);

            modelBuilder.Entity<tmsType>()
                .HasMany(e => e.tmsTicketTypes)
                .WithRequired(e => e.tmsType)
                .HasForeignKey(e => e.TypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tmsUpdate>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<tmsUpdateRequest>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<twcGuideline>()
                .Property(e => e.GuidelineText)
                .IsUnicode(false);

            modelBuilder.Entity<twcGuideline>()
                .HasMany(e => e.twcGuidelineProficiencies)
                .WithMany(e => e.twcGuidelines)
                .Map(m => m.ToTable("twcGuidelineGuidelineProficiency").MapLeftKey("GuidelineID").MapRightKey("GuidelineProficiencyID"));

            modelBuilder.Entity<twcLevel>()
                .HasMany(e => e.ContinuumDatas)
                .WithRequired(e => e.twcLevel)
                .HasForeignKey(e => e.LevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<twcLevel>()
                .HasMany(e => e.twcGuidelines)
                .WithRequired(e => e.twcLevel)
                .HasForeignKey(e => e.LevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.middleName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.pwd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.passwordHash)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.salt)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PointWinners)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ptsUserActivityScores)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.tmsTickets)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.SubmitterID);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.tmsTicketAssignee)
                .WithRequired(e => e.User);

            modelBuilder.Entity<ValidEvaluationType>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ValidEvaluationType>()
                .HasMany(e => e.ContinuumDatas)
                .WithRequired(e => e.ValidEvaluationType)
                .HasForeignKey(e => e.EvaluationTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ValidEvaluationType>()
                .HasMany(e => e.WritingGuidelines)
                .WithRequired(e => e.ValidEvaluationType)
                .HasForeignKey(e => e.detailsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<validGoalTopic>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<validGoalTopic>()
                .HasMany(e => e.GoalsIndividualStudents)
                .WithOptional(e => e.validGoalTopic)
                .HasForeignKey(e => e.goalTopicID);

            modelBuilder.Entity<ValidScoreType>()
                .Property(e => e.scoreType)
                .IsUnicode(false);

            modelBuilder.Entity<ValidScoreType>()
                .HasMany(e => e.EvaluationScores)
                .WithRequired(e => e.ValidScoreType)
                .HasForeignKey(e => e.ScoreTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ValidScoreType>()
                .HasMany(e => e.twcGuidelines)
                .WithRequired(e => e.ValidScoreType)
                .HasForeignKey(e => e.EvaluationTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WordChoice>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<WordChoice>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<WordChoice>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<WordChoice>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.structure)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.voice)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.fluency)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.conventions)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.presentation)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.writingProcess)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.research)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline>()
                .Property(e => e.attitude)
                .IsUnicode(false);

            modelBuilder.Entity<writingGuidelineDetail>()
                .Property(e => e.score)
                .IsUnicode(false);

            modelBuilder.Entity<writingGuidelineDetail>()
                .Property(e => e.averageTimePeriod)
                .IsUnicode(false);

            modelBuilder.Entity<writingGuidelineDetail>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline1>()
                .Property(e => e.guideline)
                .IsUnicode(false);

            modelBuilder.Entity<WritingGuideline1>()
                .HasMany(e => e.WritingGuidelinesLookups)
                .WithOptional(e => e.WritingGuideline)
                .HasForeignKey(e => e.guidelineID);

            modelBuilder.Entity<WritingProcess>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<WritingProcess>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<WritingProcess>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<WritingProcess>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<WritingRange>()
                .Property(e => e.cHeader)
                .IsUnicode(false);

            modelBuilder.Entity<WritingRange>()
                .Property(e => e.cDescription)
                .IsUnicode(false);

            modelBuilder.Entity<WritingRange>()
                .Property(e => e.cFooter)
                .IsUnicode(false);

            modelBuilder.Entity<WritingRange>()
                .Property(e => e.cLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Conference>()
                .Property(e => e.stageOrDraft)
                .IsUnicode(false);

            modelBuilder.Entity<Conference>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<forumThread>()
                .Property(e => e.psName)
                .IsUnicode(false);

            modelBuilder.Entity<forumThread>()
                .Property(e => e.psEmail)
                .IsUnicode(false);

            modelBuilder.Entity<forumThread>()
                .Property(e => e.psSubject)
                .IsUnicode(false);

            modelBuilder.Entity<forumThread>()
                .Property(e => e.psPost)
                .IsUnicode(false);

            modelBuilder.Entity<forumThread>()
                .Property(e => e.psIP)
                .IsUnicode(false);

            modelBuilder.Entity<forumTopic>()
                .Property(e => e.bcTitle)
                .IsUnicode(false);

            modelBuilder.Entity<forumTopic>()
                .Property(e => e.bcDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Greeting>()
                .Property(e => e.Greeting1)
                .IsUnicode(false);

            modelBuilder.Entity<NewsandUpdatesText>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Quote>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherDashboardWhatsNew>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherWhatsNew>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<validPaperType>()
                .Property(e => e.paperType)
                .IsUnicode(false);
        }
    }
}
