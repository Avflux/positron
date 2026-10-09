import type { Jumper4 } from "@protocol";
import { ouTraco } from "@/features/fiacao/FiacaoPanel";

/**
 * Jumpers do painel (`Jumper4`) — o que o comando `JMP` projeta das conexões
 * `Tipo 3`/`Tipo 4` (`frmCompilarJumperExt` do original). Ver `docs/POSITRON.md`.
 */
export function JumpersPanel({ jumpers }: { jumpers: Jumper4[] }) {
  return (
    <div className="subsection">
      <h3>
        Jumpers <span className="muted">({jumpers.length})</span>
      </h3>
      {jumpers.length === 0 ? (
        <p className="muted">sem jumpers neste painel</p>
      ) : (
        <table className="data">
          <thead>
            <tr>
              <th>Tag</th>
              <th>Terminal</th>
              <th>Régua</th>
              <th>Tipo</th>
              <th>Seção</th>
              <th>Cor</th>
            </tr>
          </thead>
          <tbody>
            {jumpers.map((jumper) => (
              <tr key={jumper.Indice}>
                <td>{ouTraco(jumper.Tag)}</td>
                <td>{ouTraco(jumper.Terminal)}</td>
                <td>{ouTraco(jumper.NRegua)}</td>
                <td>{ouTraco(jumper.Tipo)}</td>
                <td>{ouTraco(jumper.Secao)}</td>
                <td>{ouTraco(jumper.Cor)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
