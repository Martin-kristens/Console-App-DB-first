using shared.Entities;
using shared.Repositories;
using System.Diagnostics;

namespace shared.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }


    // CRUD

    public AddressEntity CreateAddress(string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressRepository.GetOne(x => x.StreetName == streetName);
            if (addressEntity == null)
            {
                addressEntity = _addressRepository.Create(new AddressEntity 
                { 
                    StreetName = streetName, 
                    PostalCode = postalCode, 
                    City = city 
                });

                return addressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    } 

    public AddressEntity GetAddress(string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressRepository.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if(addressEntity != null) 
            { 
                return addressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public AddressEntity GetAddressById(int id)
    {
        try
        {
            var addressEntity = _addressRepository.GetOne(x => x.Id == id);
            if (addressEntity != null)
            {
                return addressEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<AddressEntity> GetAddresses()
    {
        try
        {
            var addresses = _addressRepository.GetAll();
            if (addresses != null)
            {
                return addresses;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        try
        {
            var addressEntityToUpdate = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
            if (addressEntityToUpdate != null)
            {
                return addressEntityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteAddress(int id)
    {
        try
        {
            var addressEntity = _addressRepository.GetOne(x => x.Id == id);
            if (addressEntity != null)
            {
                _addressRepository.Delete(x => x.Id == id);
                return true;
            }
           
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
