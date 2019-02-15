using Senai.SviGufo.WebApi.Domais;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        /// <summary>
        /// lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lisa de tipo evento</returns>
        List<TipoEventoDomain> Listar();

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto do tipo evento domain</param>
        void Cadastra(TipoEventoDomain tipoEvento);

        void Deletar(int id);

        void Alterar(TipoEventoDomain tipoEvento);
    }
}
