using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    /// <summary>
    /// This class provides the methods for operations on Contact and related objects
    /// </summary>
    public class ContactRepository : IContactRepository, IDisposable
    {
        #region Declarations

        //Create an object of Payroll_Context
        private Payroll_Context payroll;

        private bool disposed = false;

        #endregion

        #region Constructor

        public ContactRepository(Payroll_Context payroll)
        {
            //Pass the Payroll_Context object 
            this.payroll = payroll;
        }

        #endregion

        #region Country 

        #region GetCountry
        /// <summary>
        /// Get the Country details.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<Country> GetCountry()
        {
            //Gets the countries
            return payroll.Countries.ToList().OrderBy(x=>x.CountryName);
        }
        #endregion

        #region GetCountryById
        /// <summary>
        /// Get the details of selected country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public Country GetCountryById(int countryId)
        {
            //return only rows that have the given id
            return payroll.Countries.Where(x => x.CountryId == countryId).First();
        }
        #endregion

        #region InsertCountry
        /// <summary>
        /// Insert a new country
        /// </summary>
        /// <param name="country"></param>
        public void InsertCountry(Country country)
        {
            //Adds the country object to the context
            payroll.Countries.AddObject(country);
        }
        #endregion

        #region UpdateCountry
        /// <summary>
        /// Update an existing country
        /// </summary>
        /// <param name="country"></param>
        public void UpdateCountry(Country country)
        {
            //Apply the country object changed values to the context
            payroll.Countries.ApplyCurrentValues(country);
        }
        #endregion

        #region DeleteCountry
        /// <summary>
        /// Delete a country
        /// </summary>
        /// <param name="countryId"></param>
        public void DeleteCountry(int countryId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region State 

        #region GetState
        /// <summary>
        /// Get the State details.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<State> GetState()
        {
            //return all states.
            return payroll.States.ToList().OrderBy(x => x.CountryId).ThenBy(x => x.StateName);
        }
        #endregion

        #region GetStateById
        /// <summary>
        /// Get the details of selected State.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public State GetStateById(int stateId)
        {
            //return only rows that have the given id
            return payroll.States.Where(x => x.StateId == stateId).First();
        }
        #endregion

        #region GetStateByCountryId
        /// <summary>
        /// Get the details of States with respect to the selected country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public IEnumerable<State> GetStateByCountryId(int countryId)
        {
            //return only rows that have the given id
            return payroll.States.Where(x => x.CountryId == countryId).ToList();
        }
        #endregion

        #region InsertState
        /// <summary>
        /// Insert a new state
        /// </summary>
        /// <param name="state"></param>
        public void InsertState(State state)
        {
            //Adds the country object to the context
            payroll.States.AddObject(state);
        }
        #endregion

        #region UpdateState
        /// <summary>
        /// Update an existing state
        /// </summary>
        /// <param name="state"></param>
        public void UpdateState(State state)
        {
            //Apply the state object changed values to the context
            payroll.States.ApplyCurrentValues(state);
        }
        #endregion

        #region DeleteState
        /// <summary>
        /// Delete a state
        /// </summary>
        /// <param name="stateId"></param>
        public void DeleteState(int stateId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region District 


        #region GetDistrict
        /// <summary>
        /// Get the district details.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<District> GetDistrict()
        {
            //return all.
            return payroll.Districts.ToList().OrderBy(x=>x.CountryId).ThenBy(x=>x.StateId).ThenBy(x=>x.DistrictName);
        }
        #endregion

        #region GetDistrictById
        /// <summary>
        /// Get the details of selected district.
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public District GetDistrictById(int districtId)
        {
            //return only rows that have the given id
            return payroll.Districts.Where(x => x.DistrictId == districtId).First();
        }
        #endregion

        #region GetDistrictByStateId
        /// <summary>
        /// Get the details of district with respect to the selected state.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public IEnumerable<District> GetDistrictByStateId(int stateId)
        {
            //return only rows that have the given id
            return payroll.Districts.Where(x => x.StateId == stateId);
        }
        #endregion

        #region InsertDistrict
        /// <summary>
        /// Insert a new district
        /// </summary>
        /// <param name="district"></param>
        public void InsertDistrict(District district)
        {
            //Adds the country object to the context
            payroll.Districts.AddObject(district);
        }
        #endregion

        #region UpdateDistrict
        /// <summary>
        /// Update an existing district
        /// </summary>
        /// <param name="district"></param>
        public void UpdateDistrict(District district)
        {
            //create District with given key
            //var districtOld = new District { DistrictId = district.DistrictId };

            //Attach the object
            //payroll.Districts.Attach(districtOld);

            //Apply the district object changed values to the context
            payroll.Districts.ApplyCurrentValues(district);
        }
        #endregion

        #region DeleteDistrict
        /// <summary>
        /// Delete a district
        /// </summary>
        /// <param name="districtId"></param>
        public void DeleteDistrict(int districtId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Contact 

        #region GetContact
        /// <summary>
        /// Get the Contact details.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<Contact> GetContact()
        {
            //Gets the Contacts
            return payroll.Contacts.ToList();
        }
        #endregion

        #region GetContactById
        /// <summary>
        /// Get the details of selected contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Contact GetContactById(int contactId)
        {
            //return only rows that have the given id
            return payroll.Contacts.Where(x => x.ContactId == contactId).First();
        }
        #endregion

        #region InsertContact
        /// <summary>
        /// Insert a new contact
        /// </summary>
        /// <param name="contact"></param>
        public void InsertContact(Contact contact)
        {
            //Adds the contact object to the context
            payroll.Contacts.AddObject(contact);
        }
        #endregion

        #region UpdateContact
        /// <summary>
        /// Update an existing contact
        /// </summary>
        /// <param name="contact"></param>
        public void UpdateContact(Contact contact)
        {
            //Apply the contact object changed values to the context
            payroll.Contacts.ApplyCurrentValues(contact);
        }
        #endregion

        #region DeleteContact
        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="contactId"></param>
        public void DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Save
        /// <summary>
        /// Save the object
        /// </summary>
        public void Save()
        {
            payroll.SaveChanges();
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Disposes the Payroll context(if not already done by GC)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    payroll.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose the context
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
