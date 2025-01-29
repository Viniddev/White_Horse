export default function BannerHome(){
    return (
      <div className="bannerPrincipal flexRow">
        <div className="conteinerTextBanner">
          <p className="textHome">A nova fronteira</p>
          <p className="textHome subText">do conhecimento!</p>
        </div>
        <img
          src="./logo_principal_sem_fundo.png"
          alt="logo com texto"
          className="imgBanner"
        />
      </div>
    );
}