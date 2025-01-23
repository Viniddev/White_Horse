import Link from "next/link";
import "../styles/globals.scss";
import "../styles/not_found/not_found.scss";
import { Button } from "primereact/button";

export default function NotFound() {
  return (
    <div className="flexColumn">
      <h2>A pagina não foi encontrada ou está fora do ar.</h2>
      <p>Tente novamente dentro de alguns instantes.</p>
      <Link href="/" className="btnVoltarParaAHome">
        <Button label="Voltar para a Home" icon="pi pi-arrow-left" severity="help" />
      </Link>
    </div>
  );
}
