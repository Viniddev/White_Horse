import { TiposAlerta } from "@/utils/Enums/tipoAlerta";
import "./mensagemAlertaStyle.scss";
import { MensagemAlertaProps } from "@/@types/IMensagemAlerta";

export default function MensagemAlerta({ mensagem, type }: MensagemAlertaProps) {

    const tipoAlerta = type === TiposAlerta.Buscando;

    return (
      <div className="conteinerAlerta flexRow" id={tipoAlerta ? "tipoBuscando" : "tipoNaoEncontrado"}>
        <p>{mensagem}</p>
      </div>
    );
}