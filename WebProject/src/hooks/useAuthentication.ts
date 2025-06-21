import { LOGIN } from "@/utils/frontEndUrls/urls";
import { jwtDecode } from "jwt-decode";
import { usePathname } from "next/navigation";
import React from "react";

export default function UseAuthentication(){
  const [pageLoaded, setPageLoaded] = React.useState<boolean>(false);
  const [autenticado, setAutenticado] = React.useState<boolean>(false);
  const pathname = usePathname(); 

  const checkAuth = (): boolean => {
    if (sessionStorage.getItem("Token")) {
      const token: string = sessionStorage.getItem("Token")!;
      const decoded: any = jwtDecode(token);
      const currentTime: number = parseInt(
        new Date().getTime().toString().substring(0, 10)
      );
      const expirationTime: number = parseInt(
        decoded.exp.toString().substring(0, 10)
      );
      sessionStorage.setItem("Sub", decoded.sub);
      if (currentTime > expirationTime) {
        sessionStorage.removeItem("Token");
        window.location.href = LOGIN;
        return false;
      }
      return true;
    }
    return false;
  };

  React.useEffect(() => {
    setAutenticado(checkAuth());
    setPageLoaded(true);
  }, []);

  return {
    pageLoaded,
    autenticado,
    pathname,
    checkAuth,
  };
}