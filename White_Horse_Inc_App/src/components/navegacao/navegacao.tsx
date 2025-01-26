import { HOME } from "@/utils/front_end_urls/urls";
import Link from "next/link";


export default function LinksNavegacao(){
    return (
      <>
        <Link href={HOME}>
          <img
            src="/logo_principal_sem_fundo.png"
            alt="logo"
            className="LogoHeader"
          />
        </Link>

        <Link
          href={"https://www.youtube.com/watch?v=kvVEaln7QNQ"}
          className="HeaderOption headerDesktop"
        >
          <h1 className="titleHeader">Projetos</h1>
        </Link>

        <Link
          href={"https://www.youtube.com/watch?v=kvVEaln7QNQ"}
          className="HeaderOption"
        >
          <h1 className="titleHeader headerDesktop">Sobre nós</h1>
        </Link>
      </>
    );
}