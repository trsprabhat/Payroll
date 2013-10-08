using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayrollModel;

namespace Payroll_Manager
{
    public class Contact
    {
        #region Declarations

        private IContactRepository contactRepository;

        #endregion

        #region Constructor

        public Contact()
        {
            this.contactRepository = new ContactRepository(new Payroll_Context());
        }

        #endregion

        #region Country Methods

        #region GetCountry
        /// <summary>
        /// Get the Country details.
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        public IEnumerable<Country> GetCountry()
        {

            //return all.
            return contactRepository.GetCountry();

        }

        #endregion

        #region GetCountryById
        /// <summary>
        /// Get the Country details.
        /// </summary>
        /// <param name="CasteId"></param>
        /// <returns></returns>
        public Country GetCountryById(int countryId)
        {

            //return only rows that have the given id
            return contactRepository.GetCountryById(countryId);

        }

        #endregion

        #region AddCountry
        /// <summary>
        /// Add the country details
        /// </summary>
        /// <param name="caste"></param>
        /// <returns>int</returns>
        public int AddCountry(Country country)
        {
            try
            {
                //Add country object to context
                contactRepository.InsertCountry(country);

                //Save country
                contactRepository.Save();

                //returns 1 if successfull
                return 1; 
            }
            catch
            {
                //Add details of error to a log file
                return -1;
            }
        }

        #endregion

        #region UpdateCountry
        /// <summary>
        /// Update the country details
        /// </summary>
        /// <param name="country"></param>
        /// <returns>int</returns>
        public int UpdateCountry(Country country)
        {
            try
            {
                //Add country object to context
                contactRepository.UpdateCountry(country);

                //Save country
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file

                //returns -1 if error
                return -1;
            }
        }

        #endregion


     #endregion

        #region State Methods

        #region GetState
        /// <summary>
        /// Get the State details.
        /// </summary>
        /// <param name="CasteId"></param>
        /// <returns></returns>
        public IEnumerable<State> GetState()
        {

            //return all.
            return contactRepository.GetState();

        }

        #endregion

        #region GetStateById
        /// <summary>
        /// Get the State details.
        /// </summary>
        /// <param name="CasteId"></param>
        /// <returns></returns>
        public State GetStateById(int stateId)
        {

            //return only rows that have the given id
            return contactRepository.GetStateById(stateId);

        }

        #endregion

        #region GetStateByCountryId
        /// <summary>
        /// Get the state details with respect to country.
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>

        public IEnumerable<State> GetStateByCountryId(int countryId)
        {
            //return only rows that have the given id
            return contactRepository.GetStateByCountryId(countryId);
        }
        #endregion

        #region AddState
        /// <summary>
        /// Add the state details
        /// </summary>
        /// <param name="caste"></param>
        /// <returns>int</returns>
        public int AddState(State state)
        {
            try
            {
                //Add district object to context
                contactRepository.InsertState(state);

                //Save district
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file
                return -1;
            }
        }

        #endregion      

        #region UpdateState
        /// <summary>
        /// Update the state details
        /// </summary>
        /// <param name="state"></param>
        /// <returns>int</returns>
        public int UpdateState(State state)
        {
            try
            {
                //Add state object to context
                contactRepository.UpdateState(state);

                //Save state
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file

                //returns -1 if error
                return -1;
            }
        }

        #endregion

     #endregion

        #region District Methods

        #region GetDistrict
        /// <summary>
        /// Get the district details.
        /// </summary>
        /// <param name></param>
        /// <returns></returns>

        public IEnumerable<District> GetDistrict()
        {
            return contactRepository.GetDistrict();
        }
        #endregion

        #region GetDistrictById
        /// <summary>
        /// Get the district details with respect to the Id.
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>

        public District GetDistrictById(int districtId)
        {
            //return only rows that have the given id
            return contactRepository.GetDistrictById(districtId);
        }
        #endregion

        #region GetDistrictByStateId
        /// <summary>
        /// Get the district details with respect to State.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>

        public IEnumerable<District> GetDistrictByStateId(int stateId)
        {
            //return only rows that have the given id
            return contactRepository.GetDistrictByStateId(stateId);
        }
        #endregion

        #region AddDistrict
        /// <summary>
        /// Add the district details
        /// </summary>
        /// <param name="district"></param>
        /// <returns>int</returns>
        public int AddDistrict(District district)
        {
            try
            {
                //Add district object to context
                contactRepository.InsertDistrict(district);

                //Save district
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file
                return -1;
            }
        }

        #endregion

        #region UpdateDistrict
        /// <summary>
        /// Update the district details
        /// </summary>
        /// <param name="district"></param>
        /// <returns>int</returns>
        public int UpdateDistrict(District district)
        {
            try
            {
                //Add district object to context
                contactRepository.UpdateDistrict(district);

                //Save district
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file

                //returns -1 if error
                return -1;
            }
        }

        #endregion    

     #endregion

        #region Contact Methods

        #region GetContact
        /// <summary>
        /// Get the Contact details.
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        public IEnumerable<PayrollModel.Contact> GetContact()
        {

            //return all.
            return contactRepository.GetContact();

        }

        #endregion

        #region GetContactById
        /// <summary>
        /// Get the Country details.
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public PayrollModel.Contact GetContactById(int contactId)
        {

            //return only rows that have the given id
            return contactRepository.GetContactById(contactId);

        }

        #endregion

        #region AddContact
        /// <summary>
        /// Add the contact details
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>int</returns>
        public int AddContact(PayrollModel.Contact contact)
        {
            try
            {
                //Add contact object to context
                contactRepository.InsertContact(contact);

                //Save contact
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file
                return -1;
            }
        }

        #endregion

        #region UpdateContact
        /// <summary>
        /// Update the contact details
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>int</returns>
        public int UpdateContact(PayrollModel.Contact contact)
        {
            try
            {
                //Add contact object to context
                contactRepository.UpdateContact(contact);

                //Save contact
                contactRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file

                //returns -1 if error
                return -1;
            }
        }

        #endregion

     #endregion

    }
}
