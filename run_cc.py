import os
import platform
import subprocess
import argparse

parser = argparse.ArgumentParser()
parser.add_argument("--extension", help="Extension of files to convert", default='.mpg')
parser.add_argument("--directory", help="Directory to process", default='.')
args = parser.parse_args()

# should be added to the system PATH statement
extractorname = ''
if platform.system() == 'Windows':
  extractor_name = 'ccextractorwin' 
elif platform.system() == 'Darwin':
  extractor_name = 'ccextractor'
elif platform.system() == "Linux":
  extractor_name = '/home/azureuser/data/projects/ccextractor/linux/ccextractor'

for file in os.listdir(args.directory):
  if file.endswith(args.extension):
    print(os.path.join(args.directory, file))
    subprocess.run([extractor_name,  os.path.join(args.directory, file)])        


