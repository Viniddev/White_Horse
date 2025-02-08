import { LOGIN, PROFILE } from "@/utils/frontEndUrls/urls";
import Link from "next/link";
import { Button } from "primereact/button";
import React from "react";
import DarkModeButton from "../btnDarkMode/btnDarkMode";

export default function HeaderDesktop() {
  const [IsLogged, setIsLogged] = React.useState<boolean>(false);

  React.useEffect(() => {
    if (sessionStorage.getItem("Token") != undefined) {
      setIsLogged(true);
    }
  }, []);

  function Sair(){
    sessionStorage.removeItem("Token");
    window.location.href = LOGIN;
  }

  return (
    <nav className="flexRow headerDesktop">
      {!IsLogged ? (
        <Link href={LOGIN}>
          <Button label="Login" outlined />
        </Link>
      ) : (
        ""
      )}

      {IsLogged ? (
        <Button 
          label="Sair"
          severity="danger" 
          outlined
          type="button" 
          onClick={Sair}/>
      ) : (
        ""
      )}

      <DarkModeButton />

      <Link href={IsLogged ? PROFILE : LOGIN}>
        <img src="/profile.png" alt="profile" className="LogoHeader" />
      </Link>
    </nav>
  );
}
