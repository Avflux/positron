import xml.etree.ElementTree as ET
import base64
import os

resx_path = 'cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4.Resources.resx'
out_dir = 'cad-plugin/lib/Recursos'
os.makedirs(out_dir, exist_ok=True)

tree = ET.parse(resx_path)
root = tree.getroot()

resources = ['MascaraM', 'ErroFiacao', 'V_B_BORNECPFL', 'Revisao']
for name in resources:
    elem = root.find(f".//data[@name='{name}']/value")
    if elem is not None and elem.text:
        raw = base64.b64decode(elem.text.strip())
        out_file = os.path.join(out_dir, f"{name}.dwg")
        with open(out_file, 'wb') as f:
            f.write(raw)
        print(f"Extracted {name}.dwg: {len(raw)} bytes, magic: {raw[:6]}")
    else:
        print(f"Not found: {name}")
