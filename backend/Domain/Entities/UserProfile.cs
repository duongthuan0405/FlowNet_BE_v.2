using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProfile
    {
        private Guid _id = Guid.Empty;
        private string _lastName = string.Empty;
        private string _firstName = string.Empty;
        private DateTimeOffset _dateOfBirth = DateTimeOffset.UtcNow;
        private Gender _gender = Gender.Other;
        private string _coverURL = string.Empty;
        private string _avatarURL = string.Empty;

        public Guid Id { get => _id; set => _id = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public DateTimeOffset DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public string CoverURL { get => _coverURL; set => _coverURL = value; }
        public string AvatarURL { get => _avatarURL; set => _avatarURL = value; }
    }
}
