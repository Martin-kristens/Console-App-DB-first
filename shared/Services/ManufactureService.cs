using shared.Entities;
using shared.Repositories;
using System.Diagnostics;

namespace shared.Services;

public class ManufactureService
{
    private readonly ManufactureRepository _manufactureRepository;

    public ManufactureService(ManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }


    // CRUD

    public ManufactureEntity CreateManufacture(string manufactureName)
    {
        try
        {
            var manufactureEntity = _manufactureRepository.GetOne(x => x.ManufactureName == manufactureName);
            if (manufactureEntity == null)
            {
                manufactureEntity = _manufactureRepository.Create(new ManufactureEntity{ ManufactureName = manufactureName,});

                return manufactureEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ManufactureEntity GetManufactureByManufactureName(string manufactureName)
    {
        try
        {
            var manufactureEntity = _manufactureRepository.GetOne(x => x.ManufactureName == manufactureName);
            if (manufactureEntity != null)
            {
                return manufactureEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ManufactureEntity GetManufactureById(int id)
    {
        try
        {
            var manufactureEntity = _manufactureRepository.GetOne(x => x.Id == id);
            if (manufactureEntity != null)
            {
                return manufactureEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<ManufactureEntity> GetManufactures()
    {
        try
        {
            var manufactures = _manufactureRepository.GetAll();
            if (manufactures != null)
            {
                return manufactures;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ManufactureEntity UpdateManufacture(ManufactureEntity ManufactureEntity)
    {
        try
        {
            var manufactureEntityToUpdate = _manufactureRepository.Update(x => x.Id == ManufactureEntity.Id, ManufactureEntity);
            if (manufactureEntityToUpdate != null)
            {
                return manufactureEntityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteManufacture(int id)
    {
        try
        {
            var manufactureEntity = _manufactureRepository.GetOne(x => x.Id == id);
            if (manufactureEntity != null)
            {
                _manufactureRepository.Delete(x => x.Id == id);
                return true;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
