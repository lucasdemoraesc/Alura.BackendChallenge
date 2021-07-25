using Alura.BackendChallenge.Dominio.Objetos;

namespace Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio
{
    /// <summary>
    /// Interface de repositório genérico.
    /// </summary>
    /// <typeparam name="TObjeto"><see cref="ObjetoBase"/></typeparam>
    public interface IRepositorioGenerico<TObjeto> where TObjeto : ObjetoBase
    {

    }
}
