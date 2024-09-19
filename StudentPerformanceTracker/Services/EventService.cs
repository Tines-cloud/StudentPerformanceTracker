using SPTKnowledgeService.DTO;
using SPTUserService.DTO;
using StudentPerformanceTracker.API_Service;
using StudentPerformanceTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

    namespace StudentPerformanceTracker.Services
    {
    public static class EventService
    {
        public static UserDTO CurrentUser { get; set; }
        public static bool isStudying { get; set; }
        public static bool isBreak { get; set; }
        public static TimeSpan BreakStartTime { get; set; }
        public static StudySessionDTO StudySession { get; set; }
        public static BreakDTO Break { get; set; }

        private static readonly UserServiceClient _userServiceClient = new UserServiceClient();
        private static readonly SubjectServiceClient _subjectServiceClient = new SubjectServiceClient();
        private static readonly KnowledgeServiceClient _knowledgeServiceClient = new KnowledgeServiceClient();

        public static async Task SetStudySessions(string subjectCode)
        {
            if (!isStudying)
            {
                isStudying = true;
                StudySession = new StudySessionDTO
                {
                    Date = DateTime.Now.Date,
                    StartTime = DateTime.Now.TimeOfDay
                };
                var subjectDTO = await _subjectServiceClient.GetSubjectBySubjectCodeAsync(subjectCode);

                Break = new BreakDTO
                {
                    SessionId = StudySession.Id,
                    Date = DateTime.Now.Date,
                    BreakDurations = new List<TimeSpan>()
                };

                StudySession.Subject = subjectDTO;
                Break.Subject = subjectDTO;
            }
            else
            {
                isBreak = false;
                AddBreakDurations();
            }
        }

        public static async Task SetBreaks()
        {
            if (isStudying)
            {
                isBreak = true;
                BreakStartTime = DateTime.Now.TimeOfDay;
            }
        }

        public static void AddBreakDurations()
        {
            double duration = Math.Round((DateTime.Now.TimeOfDay - BreakStartTime).TotalMinutes, 2);
            if (duration > 0)
            {
                Break.BreakDurations.Add(TimeSpan.FromMinutes(duration));
            }
        }

        public static async Task EndStudy()
        {
            if (isStudying)
            {
                isStudying = false;

                if (isBreak)
                {
                    AddBreakDurations();
                }

                StudySession.EndTime = DateTime.Now.TimeOfDay;
                await _knowledgeServiceClient.AddStudySessionAsync(StudySession);
            }
        }

        public static async Task AddOrUpdateKnowledge(KnowledgeDTO knowledge, bool isNew)
        {
            if (isNew)
            {
                await _knowledgeServiceClient.AddKnowledgeAsync(knowledge);
            }
            else
            {
                await _knowledgeServiceClient.UpdateKnowledgeAsync(knowledge);
            }
        }

        public static async Task RemoveKnowledge(int id)
        {
            await _knowledgeServiceClient.DeleteKnowledgeAsync(id);
        }

        public static async Task SaveUser(UserDTO user)
        {
            await _userServiceClient.UpdateUserAsync(user.Username, user);
            CurrentUser = user;
        }

        public static async Task RemoveUser(UserDTO user)
        {
            await _userServiceClient.DeleteUserAsync(user.Username);
        }

        public static async Task AddOrUpdateUser(UserDTO user, bool isNew)
        {
            if (isNew)
            {
                await _userServiceClient.AddUserAsync(user);
            }
            else
            {
                await _userServiceClient.UpdateUserAsync(user.Username, user);
            }
        }

        public static async Task<UserDTO> Login(string username, string password)
        {
            var user = await _userServiceClient.LoginAsync(username, password);
            CurrentUser = user;
            return user;
        }

        public static string GetEnumDisplayName(Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                                            .GetField(enumValue.ToString())
                                            .GetCustomAttribute<DisplayAttribute>();
            return displayAttribute?.Name ?? enumValue.ToString();
        }

        public static List<KeyValuePair<Grade, string>> GetEnumDisplayNames<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(e => new KeyValuePair<Grade, string>((Grade)(object)e, GetEnumDisplayName((Enum)(object)e)))
                       .ToList();
        }

        public static async Task RemoveBreak(int id)
        {
            await _knowledgeServiceClient.DeleteBreakAsync(id);
        }

        public static async Task RemoveStudySession(int id)
        {
            await _knowledgeServiceClient.DeleteStudySessionAsync(id);
        }

        public static async Task AddOrUpdateSubject(SubjectDTO subject, bool isNew)
        {
            if (isNew)
            {
                await _subjectServiceClient.AddSubjectAsync(subject);
            }
            else
            {
                await _subjectServiceClient.UpdateSubjectAsync(subject.SubjectCode, subject);
            }
        }

        public static async Task RemoveSubject(SubjectDTO subject)
        {
            await _subjectServiceClient.DeleteSubjectAsync(subject.SubjectCode);
        }
    }
}
