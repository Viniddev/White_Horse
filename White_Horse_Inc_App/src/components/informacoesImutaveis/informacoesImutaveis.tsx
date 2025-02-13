import { BuildDefaultForm } from "@/@types/components";


export default function InformacoesImutaveis({ DefaultUserInformations }: BuildDefaultForm){
    return (
      <>
        <h1 className="tituloProfile">{DefaultUserInformations.name}</h1>
        <div>
          <h2 className="imutableInformations">CPF: {DefaultUserInformations.cpf}</h2>
          <h2 className="imutableInformations">Rg: {DefaultUserInformations.rg}</h2>
          <h2 className="imutableInformations">
            CARGO: {DefaultUserInformations.role}
          </h2>
        </div>
      </>
    );
}