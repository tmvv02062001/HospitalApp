using Hospital_Managment.Models;

namespace Hospital_Managment.Services
{
    public interface IBillingService
    {
        void InsertBilling(Billings billing);
        List<Billings> GetAllPatientBillings();
        void DeleteBilling(int billingId);
        Billings GetBillingById(int billingId);
        void UpdateBilling(Billings billing);
    }
}

//Let's refine them slightly for clarity and good design:

//For GetbDetails (which performs an insert): Instead of void GetbDetails(Billings bs), use void **InsertBilling**(Billings billing).

//For PatientDetails (which gets all): Instead of List<Billings> PatientDetails(), use List<Billings> **GetAllPatientBillings**().

//For DeleteBP (which deletes): Instead of void DeleteBP(int id), use void **DeleteBilling**(int billingId). (Using billingId for clarity instead of just id).

//For EditData (which gets by ID): Instead of Billings EditData(int id), use Billings **GetBillingById**(int billingId).

//For UpdateData (which updates): Instead of void UpdateData(Billings b), use void **UpdateBilling**(Billings billing).