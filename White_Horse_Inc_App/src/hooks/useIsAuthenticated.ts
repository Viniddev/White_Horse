import { LOGIN } from "@/utils/frontEndUrls/urls";
import React from "react";

export function IsAuthenticated(){
    const [IsLogged, setIsLogged] = React.useState<boolean>(false);

    React.useEffect(() => {
    if (sessionStorage.getItem("Token") != undefined) {
        setIsLogged(true);
    }
    }, []);

    function Sair() {
        sessionStorage.removeItem("Token");
        window.location.href = LOGIN;
    }

    return { IsLogged, setIsLogged, Sair };
}