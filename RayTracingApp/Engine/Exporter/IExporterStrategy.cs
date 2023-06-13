using System.Drawing;

namespace Engine.Exporter
{
	public interface IExporterStrategy
	{
		void Export(string path, Image img);
	}
}
