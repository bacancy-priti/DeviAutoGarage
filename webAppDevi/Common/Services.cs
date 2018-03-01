using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webAppDevi.Models;
using webAppDevi.Common;

namespace webAppDevi.Common
{
    public class Services
    {
        DeviAutoEntities entity = new DeviAutoEntities();

        #region Bike Brand Services
        List<BikeBrand> list = new List<BikeBrand>();
        BikeBrand brand = new BikeBrand();
        bool isAction = false;
        public List<BikeBrand> GetAllBikeBrand()
        {
            try
            {
                list = entity.BikeBrands.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Add(BikeBrand bb)
        {
            try
            {
                brand.BikeBrandName = bb.BikeBrandName;
                brand.IsDeleted = false;
                entity.BikeBrands.Add(brand);
                entity.SaveChanges();

                isAction = true;
            }
            catch (Exception ex)
            {
                isAction = false;
            }
            return isAction;
        }
        public bool Edit(BikeBrand bb)
        {
            try
            {
                var sigleBrand = entity.BikeBrands.FirstOrDefault(c => c.BikeBrandId == bb.BikeBrandId);
                sigleBrand.BikeBrandName = brand.BikeBrandName;
                entity.SaveChanges();

                isAction = true;
            }
            catch (Exception ex)
            {
                isAction = false;
            }
            return isAction;
        }
        public bool Delete(int id)
        {
            try
            {
                var sigleBrand = entity.BikeBrands.FirstOrDefault(c => c.BikeBrandId == id);
                if (sigleBrand != null)
                {
                    entity.BikeBrands.Remove(sigleBrand);
                    entity.SaveChanges();
                }
                isAction = true;
            }
            catch (Exception ex)
            {
                isAction = false;
            }
            return isAction;
        }
        #endregion

        #region User service
        User u = new User();
        public User GetUserByUserNameOrEmailAndPassword(string username, string password)
        {
            string pass = EncryptDycrypt.Encrypt(password);
            u = entity.Users.FirstOrDefault(c => ((c.UserName == username)
                                            || c.EmailId == username)
                                            && (c.Password == pass));
            return u;
        }
        #endregion
    }
}