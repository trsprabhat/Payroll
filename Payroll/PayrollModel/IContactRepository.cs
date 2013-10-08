using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public interface IContactRepository : IDisposable
    {
        #region Country

        IEnumerable<Country> GetCountry();

        Country GetCountryById(int countryId);

        void InsertCountry(Country country);

        void UpdateCountry(Country country);

        void DeleteCountry(int countryId);

        #endregion

        #region State

        IEnumerable<State> GetState();

        State GetStateById(int stateId);

        IEnumerable<State> GetStateByCountryId(int countryId);

        void InsertState(State state);

        void UpdateState(State state);

        void DeleteState(int stateId);

        #endregion

        #region District

        IEnumerable<District> GetDistrict();

        District GetDistrictById(int districtId);

        IEnumerable<District> GetDistrictByStateId(int stateId);

        void InsertDistrict(District district);

        void UpdateDistrict(District district);

        void DeleteDistrict(int districtId);

        #endregion

        #region Contact

        IEnumerable<Contact> GetContact();

        Contact GetContactById(int contactId);

        void InsertContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(int countryId);

        #endregion

        #region Save

        void Save();

        #endregion
    }
}
