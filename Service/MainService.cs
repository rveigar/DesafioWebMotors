using DesafioWebMotors.Models;
using DesafioWebMotors.Repository;
using System.Collections.Generic;

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
        public List<Anuncio> ListarAnuncios()
        {
            var resposta = _mainRepository.ListarAnuncios();
            return resposta;

        }

        public void ExcluirAnuncio(int idAnuncio)
        {
            _mainRepository.ExcluirAnuncio(idAnuncio);
        }

        public void AtualizarAnuncio(Anuncio anuncio, int idAnuncio)
        {
             _mainRepository.AtualizarAnuncio(anuncio , idAnuncio);
        }

        public Anuncio SelecionarAnuncio(int id)
        {
            _mainRepository = new MainRepository();
            var resultado = _mainRepository.SelecionarAnuncio(id);
            return resultado;
        }

    }
}
