using System.Collections.Generic;

namespace HappyPaws.Model
{
    public class PetAppointmentViewModel
    {
        public Pet Pet { get; set; }
        public MedicalServiceHeader MedicalServiceHeader { get; set; }

        public AppointmentDetails AppointmentDetails { get; set; }

        public List<MedicalService> MedicalServiceList { get; set; }
        public List<MedicalServiceShoppingCart> MedicalServiceShoppingCart { get; set; }



    }
}
