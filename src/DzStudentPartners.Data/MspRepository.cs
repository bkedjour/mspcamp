using System.Collections.Generic;
using System.Linq;
using DzStudentPartners.Core;
using DzStudentPartners.Domain;
using Microsoft.EntityFrameworkCore;

namespace DzStudentPartners.Data
{
    public class MspRepository : IMspRepository
    {
        private MspContext _context;

        public MspRepository(MspContext context)
        {
            _context = context;
        }
        public void AddMsp(Msp msp)
        {
            _context.Msps.Add(msp);
            _context.SaveChanges();
        }

        public List<MspCamp> GetAllCamps()
        {
            return _context.Camps
                    .Include(c => c.Location)
                    .ToList();
        }

        public List<Msp> GetAllMsps(string campTag)
        {
            return _context.Msps.Where(m => m.Camp.Tag == campTag).ToList();
        }

        public List<Msp> GetAllMspsWithSkills(string campTag)
        {
            return _context.Msps
                        .Where(m => m.Camp.Tag == campTag)
                        .Include(m => m.Skills)
                        .ToList();
        }

        public MspCamp GetCampById(int id)
        {
            return _context.Camps
                        .Include(c => c.Location)
                        .FirstOrDefault(c => c.Id == id);
        }

        public MspCamp GetCampByTag(string tag)
        {
            return _context.Camps
                        .Include(c => c.Location)
                        .FirstOrDefault(c => c.Tag == tag);
        }
        public void RemoveMsp(Msp msp)
        {
            _context.Msps.Remove(msp);
            _context.SaveChanges();
        }

        public void AddCamp(MspCamp camp)
        {
            _context.Camps.Add(camp);
            _context.SaveChanges();
        }

        public Msp GetMspById(int id)
        {
            return _context.Msps
                            .Include(m => m.Camp)
                            .FirstOrDefault(m => m.Id == id);
        }

        public Msp GetMspWithSkillsById(int id)
        {
            return _context.Msps
                            .Include(m => m.Camp)
                            .Include(m => m.Skills)
                            .FirstOrDefault(m => m.Id == id);
        }

        public List<Skill> GetSkills(int mspId)
        {
            return _context.Msps
                            .Include(m => m.Skills)
                            .FirstOrDefault(m => m.Id == mspId)
                            ?.Skills.ToList();
        }
    }
}