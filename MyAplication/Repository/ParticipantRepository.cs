using System.Collections.Generic;
using System.Linq;
using ProyectoUT5;
using ProyectoUT5.Handler;

namespace ProyectoUT5.Repository
{
    public class ParticipantRepository
    {
        private List<Participant> participantsList = new List<Participant>();
        private static ParticipantRepository instance;

        //Singleton instancia unica
        public static ParticipantRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParticipantRepository();
                }

                return instance;
            }
        }

        public ParticipantRepository(){
        }

        public List<Participant> GetParticipantsByDiscipline(string discipline)

        {
            participantsList = UserRepository.Instance.LoadParticipantsList();
        
            var matchingParticipants = participantsList.Where(p => p.Discipline.Equals(discipline, StringComparison.OrdinalIgnoreCase)).ToList();
            
            return matchingParticipants;
        }
    

    }
}