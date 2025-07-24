import "../visualizations.scss"

export default async function Page({ params }: {
  params: Promise<{ slug: string }>;
}) {
  const { slug } = await params;

  return (
    <div className="flexRow conteinerPosts">
      work in progress: <br /> {slug}
    </div>
  )
}
