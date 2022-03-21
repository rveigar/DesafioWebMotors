using DesafioWebMotors.Models;
using DesafioWebMotors.Repository;

namespace DesafioWebMotors.Service
{
    public class MainService
    {
        private MainRepository _mainRepository;
        public MainService()
        {
            _mainRepository = new MainRepository();
        }
        public void Adicionar (Anuncio anuncio)
        {
            _mainRepository.InsertAnuncio(anuncio);
        }
    }
}
