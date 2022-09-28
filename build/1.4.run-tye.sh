#! usr/bin/bash

# Go to root
source ./utils.sh
to-root 

# Redirect to tye folder
cd build/tye

# Excute
tye run --watch