import { TiposAlerta } from "@/utils/Enums/tipoAlerta";

export interface MensagemAlertaProps {
  mensagem: string;
  type: TiposAlerta;
}
