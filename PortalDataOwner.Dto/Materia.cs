using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Dto
{
    public class Materia
    {
        public string skAnuncio { get; set; }
        public string pkChaveImportacao { get; set; }
        public string pkCliente { get; set; }
        public Int64? pkAnuncio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtAnuncio { get; set; }
        public string stVeiculo { get; set; }
        public int? stTipoVeiculo { get; set; }
        public string stTierVeiculo { get; set; }
        public string stTitulo { get; set; }
        public string stMidia { get; set; }
        public string stTipoMidia { get; set; }
        public string stProvacacao { get; set; }
        public string stSentimento { get; set; }
        public Int64? nmAudiencia { get; set; }
        public string stAssunto { get; set; }
        public string stSubAssunto { get; set; }
        public string stProtagonismo { get; set; }
        public string stEditora { get; set; }
        public string stLink { get; set; }
        public string stUF { get; set; }
        public string stCidade { get; set; }
        public float nmInteracoes { get; set; }
        public Int64? nmViews { get; set; }
        public float? nmResultado { get; set; }
        public int? snFoto { get; set; }
        public int? snVideos { get; set; }
        public int? snInfografos { get; set; }
        public int? snSubLink { get; set; }
        public int? snTitulo { get; set; }
        public int? snDestaque { get; set; }
        public string stClipadora { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dtCarga { get; set; }

    }
}
