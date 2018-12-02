using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using TravelDetroit.Data.DAL;
using TravelDetroit.Service.Models;

namespace TravelDetroit.Service.Methods
{
    public class UserProfileService
    {
        public List<UserProfile> UserSearchByName(string name)
        {
            return AutoMapper.Mapper.Map<List<UserProfile>>(new UserProfileRepository().SearchByName(name));
        }

        public Models.UserProfile GetUserProfile(int id)
        {
            return AutoMapper.Mapper.Map<UserProfile>(new UserProfileRepository().Read(id));
        }

        public Models.UserProfile GetCurrentUserProfile()
        {
            return AutoMapper.Mapper.Map<UserProfile>(new UserProfileRepository().GetCurrentUserProfile());
        }
    }
}