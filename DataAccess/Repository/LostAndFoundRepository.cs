using DataAccess.DBModels;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net;
//using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Repository
{
    public class LostAndFoundRepository : ILostAndFoundRepository
    {
        LfDBContext _dBContext;
        public LostAndFoundRepository(LfDBContext _dBContext)
        {
            this._dBContext = _dBContext;
        }

        public async Task<List<LostAndFound>> GetAllLostsAndFounds()
        {
            List<LostAndFound> lostAndFoundList = await _dBContext.LostAndFounds.OrderByDescending(d => d.DatePublished).ToListAsync();
            return lostAndFoundList;
        }
        public async Task<List<LostAndFoundWithNameDTO>> GetAllLostsAndFounds2()
        {
            List<LostAndFoundWithNameDTO> lostAndFoundList = await _dBContext.LostAndFounds.Include(d => d.SubCategory).Include(d => d.Type).Select(a => new LostAndFoundWithNameDTO()
            {
                Id = a.Id,
                TypeId = a.TypeId,
                StatusId = a.StatusId,
                UserId = a.UserId,
                CategoryId = a.CategoryId,
                SubCategoryId = a.SubCategoryId,
                DatePublished = a.DatePublished,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                Email = a.Email,
                Phone = a.Phone,
                Common = a.Common,
                GetEmail = a.GetEmail,
                SubCategoryName = a.SubCategory.SubCategoryName,
                TypeName = a.Type.TypeName

            }).ToListAsync();
            //adCities(lostAndFoundList);

            return lostAndFoundList;
        }
        public async Task<List<LostAndFound>> GetByParams(int typeId, int categoryId)
        {

            var lostAndFoundList = await (from l in _dBContext.LostAndFounds
                                          where ((typeId == -1) || (l.TypeId == typeId)) && ((categoryId == -1) || (l.CategoryId == categoryId))
                                          select l).ToListAsync();
            return lostAndFoundList;
        }
        public async Task<List<LostAndFoundWithNameDTO>> GetByAdvancedSearch(int userId = -1, int typeId = -1, int categoryId = -1, int subCategoryId = -1, DateTime? startDatePublished = null, DateTime? endDatePublished = null, DateTime? startDate = null, DateTime? endDate = null, string? common = "defaultValue", string city = "defaultValue")
        {


            List<LostAndFoundWithNameDTO> lostAndFoundList = await _dBContext.LostAndFounds.Include(d => d.SubCategory).Include(d => d.Type).Where(d => (((typeId == -1) || (d.TypeId == typeId)) &&
                                          ((categoryId == -1) || (d.CategoryId == categoryId)) &&
                                          ((userId == -1) || (d.UserId == userId)) &&
                                          ((subCategoryId == -1) || (d.SubCategoryId == subCategoryId)) &&
                                          ((startDatePublished == null) || ((d.DatePublished < endDatePublished) && (d.DatePublished > startDatePublished))) &&
                                          (((d.StartDate <= endDate) && (endDate <= d.EndDate)) || (startDate <= d.EndDate)
                                          && (d.EndDate <= endDate) || ((startDate == null) && (endDate == null)) || ((startDate == null)
                                          && (endDate >= d.StartDate)) || ((endDate == null) && (startDate <= d.EndDate))))).Select(a => new LostAndFoundWithNameDTO()
                                          {
                                              Id = a.Id,
                                              TypeId = a.TypeId,
                                              StatusId = a.StatusId,
                                              UserId = a.UserId,
                                              CategoryId = a.CategoryId,
                                              SubCategoryId = a.SubCategoryId,
                                              DatePublished = a.DatePublished,
                                              StartDate = a.StartDate,
                                              EndDate = a.EndDate,
                                              Email = a.Email,
                                              Phone = a.Phone,
                                              Common = a.Common,
                                              Image = a.Image,
                                              GetEmail = a.GetEmail,
                                              SubCategoryName = a.SubCategory.SubCategoryName,
                                              TypeName = a.Type.TypeName

                                          }).OrderByDescending(d => d.DatePublished).ToListAsync();

            List<LostAndFoundWithNameDTO> lf = new();
            if (common != "defaultValue")
            {
                foreach (var item in lostAndFoundList)
                {
                    item.Common = item.Common.ToLower();
                    common = common.ToLower();
                    string[] s = new string[item.Common.Length];
                    s = item.Common.Split(" ");
                    if (s[0] != "")
                    {
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].Contains(common))
                            {
                                lf.Add(item);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                addCities(lostAndFoundList);
                List<LostAndFoundWithNameDTO> lfByCity = lostAndFoundList.FindAll(lf => lf.Cities.Exists(c => c == city || city == "defaultValue" || city.Contains(c)));
                return lfByCity;
            }
            addCities(lf);
            List<LostAndFoundWithNameDTO> lfByCity2 = lf.FindAll(lf => lf.Cities.Exists(c => c == city || city == "defaultValue" || city.Contains(c)));
            return lfByCity2;
        }
        public async Task<List<LostAndFoundWithNameDTO>> GetAdsByUserId(int userId)
        {
            List<LostAndFoundWithNameDTO> lostAndFoundList = await _dBContext.LostAndFounds.Include(d => d.SubCategory).Include(d => d.Type).Where(d => (d.UserId == userId)
                                         ).Select(a => new LostAndFoundWithNameDTO()
                                         {
                                             Id = a.Id,
                                             TypeId = a.TypeId,
                                             StatusId = a.StatusId,
                                             UserId = a.UserId,
                                             CategoryId = a.CategoryId,
                                             SubCategoryId = a.SubCategoryId,
                                             DatePublished = a.DatePublished,
                                             StartDate = a.StartDate,
                                             EndDate = a.EndDate,
                                             Email = a.Email,
                                             Phone = a.Phone,
                                             Common = a.Common,
                                             GetEmail = a.GetEmail,
                                             SubCategoryName = a.SubCategory.SubCategoryName,
                                             TypeName = a.Type.TypeName
                                         }).ToListAsync();
            return lostAndFoundList;
        }

        public async Task<LostAndFound> AddAd(LostAndFound lf, List<string> cities)
        {

            Console.WriteLine(cities);
            _dBContext.LostAndFounds.Add(lf);
            //DBModels.Image image1 = new DBModels.Image() { FilePath = "images/" + userfile.FileName, FileName = userfile.FileName };
            //await _dBContext.AddAsync(image1);
            await _dBContext.SaveChangesAsync();
            foreach (var item in cities)
            {
                List<int> id = await _dBContext.Cities.Where(a => a.CityName == item).Select(a => a.CityId).ToListAsync();
                CityByAd c = new CityByAd() { CityId = id[0], AdId = lf.Id };
                _dBContext.CityByAds.Add(c);
                await _dBContext.SaveChangesAsync();
            }
            sendEmail(lf.SubCategoryId);
            return lf;
        }

        public void sendEmail(int? subCategoryId)
        {
            foreach (var item in _dBContext.LostAndFounds)
            {
                if (item.SubCategoryId == subCategoryId && item.TypeId == 1 && item.GetEmail == true)
                {
                    //if (item.Email == "36214123655@mby.co.il")

                    using (SmtpClient client = new SmtpClient()
                    {
                        Host = "smtp.office365.com",
                        Port = 587,
                        UseDefaultCredentials = false, // This require to be before setting Credentials property
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("36214387995@mby.co.il", "Student@264"), // you must give a full email address for authentication 
                        TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                        EnableSsl = true // Set to avoid secure connection exception
                    })
                    {

                        MailMessage message = new MailMessage()
                        {
                            From = new MailAddress("36214387995@mby.co.il"), // sender must be a full email address
                            Subject = "הודעה מאתר השבת אבידה",
                            IsBodyHtml = true,
                            // Body = "http://localhost:3000",
                            Body = "<h5>לתשומת ליבך נכנסה מודעה חדשה שיכולה לעניין אותך</h5><br><a href=\"http://localhost:3000\">לכניסה לאתר לחץ כאן</a>",

                            BodyEncoding = System.Text.Encoding.UTF8,
                            SubjectEncoding = System.Text.Encoding.UTF8,

                        };

                        message.To.Add(item.Email);

                        try
                        {
                            client.Send(message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
            }
        }

        public async Task<LostAndFound> UpdateAd(LostAndFound lf, List<string> cities, int adId)
        {
            try
            {
                lf.Id = adId;
                Console.WriteLine(lf.Id);
                _dBContext.LostAndFounds.Update(lf);
                await _dBContext.SaveChangesAsync();

                foreach (var city in _dBContext.CityByAds)
                {
                    if (city.AdId == lf.Id)
                    {
                        Console.WriteLine(city.CityByAdId);
                        _dBContext.CityByAds.Remove(city);

                    }

                }
                foreach (var item in cities)
                {
                    List<int> id = await _dBContext.Cities.Where(a => a.CityName == item).Select(a => a.CityId).ToListAsync();
                    CityByAd c = new CityByAd() { CityId = id[0], AdId = lf.Id };
                    _dBContext.CityByAds.Add(c);
                }
                await _dBContext.SaveChangesAsync();
                return lf;

            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("Error in UpdateAd function" + ex.Message);

            }

        }
        public List<LostAndFoundWithNameDTO> addCities(List<LostAndFoundWithNameDTO> list)
        {
            list.ForEach(item =>
            {
                List<string> cities = _dBContext.CityByAds.Include(d => d.City).Where(d => d.AdId == item.Id).Select(city => city.City.CityName).ToList();
                item.Cities = cities;

            });
            
            return list;
        }
        public async Task SetPicture(int studentId, string fileName)
        {
            try
            {
                LostAndFound s = _dBContext.LostAndFounds.Find(studentId);
                if (s != null)
                {
                    s.Image = fileName;
                    _dBContext.Update(s);
                    await _dBContext.SaveChangesAsync();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetPicture function " + ex.Message);
            }
        }
        //hi
        public async Task UploadFile(int lfId, IFormFile userfile)
        {
            try
            {
                DBModels.Image image = new DBModels.Image() { FilePath = "images/" + userfile.FileName, FileName = userfile.FileName };
                await _dBContext.AddAsync(image);
                LostAndFound l = _dBContext.LostAndFounds.Find(lfId);
                l.Image = image.FilePath;
                _dBContext.LostAndFounds.Update(l);
                await _dBContext.SaveChangesAsync();

            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetPicture function " + ex.Message);
            }
        }

    }
}
