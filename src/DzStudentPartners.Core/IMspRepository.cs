using System.Collections.Generic;
using DzStudentPartners.Domain;

namespace DzStudentPartners.Core
{
    public interface IMspRepository
    {
        List<MspCamp> GetAllCamps();

        MspCamp GetCampById(int id);

        MspCamp GetCampByTag(string tag);

        void AddCamp(MspCamp camp);

        void AddMsp(Msp msp);

        void RemoveMsp(Msp msp);

        List<Msp> GetAllMsps(string campTag);

        List<Msp> GetAllMspsWithSkills(string campTag);

        Msp GetMspById(int id);

        Msp GetMspWithSkillsById(int id);

        List<Skill> GetSkills(int mspId);

    }
}